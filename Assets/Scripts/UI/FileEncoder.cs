using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = System.Random;

public class FileEncoder
{
    public static int WordsCount
    {
        get
        {
            if (_wordsCount == 0)
            {
                string[] words;
                words = _text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                

                _wordsCount = words.Length;
            }

            return _wordsCount;
        }
        
        private set => _wordsCount = value;
    }

    private static int _wordsCount = 0;
    private static string _text;

    public static void Init(string text)
    {
        _text = text;
    }

    public static string GetEncodedFile()
    {
        Regex regex = new Regex("[a-zA-Z0-9]");
        
        var words = _text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var positions = GetOpenPositions();
        
        for (var i = 0; i < words.Length; i++)
        {
            
            if (!positions.Contains(i))
            {
                words[i] = regex.Replace(words[i], "_");
            }
        }

        return string.Join(" ", words);
    }

    public static void AddOpenPositions(List<int> positions)
    {
        var pos = GetOpenPositions();
        
        foreach (var position in positions)
        {
            if(!pos.Contains(position))
            {
                pos.Add(position);
            }
        }
        
        PlayerPrefs.SetString("positions", string.Join(",", pos));
    }

    public static List<int> GetOpenPositions()
    {
        var positions = PlayerPrefs.GetString("positions");
        
        var numbers = positions.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (numbers.Length == 0)
            return new List<int>();
            
        return numbers.Select(int.Parse).ToList();
    }

    public static List<int> GeneratePositionsToOpen(int count)
    {
        var random = new Random();
        var positions = GetOpenPositions();
        var result = new List<int>();
        for (int i = 0; i < count; i++)
        {
            int position;
            do
            {
                position = random.Next(0, WordsCount);
            } while (positions.Contains(position));
            
            result.Add(position);
        }

        return result;
    }
}
