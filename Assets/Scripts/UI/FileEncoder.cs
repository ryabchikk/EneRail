using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class FileEncoder
{
    private static string filePath = "Assets/Files/file.txt";
    private static string positionsPath = "Assets/Files/positions.txt";

    public static int WordsCount
    {
        get
        {
            if (_wordsCount == 0)
            {
                string[] words;
                using (var sr = new StreamReader(filePath))
                {
                    words = sr.ReadToEnd().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }

                _wordsCount = words.Length;
            }

            return _wordsCount;
        }
        
        private set => _wordsCount = value;
    }

    private static int _wordsCount = 0;

    public static string GetEncodedFile()
    {
        Regex regex = new Regex("[a-zA-Z0-9]");
        using var sr = new StreamReader(filePath);
        
        var words = sr.ReadToEnd().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
        using var sw = new StreamWriter(File.Open(positionsPath, FileMode.Append));
        
        foreach (var position in positions)
        {
            sw.Write(position);
            sw.Write(",");
        }
    }

    public static int[] GetOpenPositions()
    {
        using var sr = new StreamReader(positionsPath);
        
        var numbers = sr.ReadToEnd().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (numbers.Length == 0)
            return new int[] {};
            
        return numbers.Select(int.Parse).ToArray();
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
