using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEncodedFile : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private string text;
    private FileEncoder encoder;
    
    private void Start()
    {
        FileEncoder.Init(text);
        uiText.text = FileEncoder.GetEncodedFile();
    }
}
