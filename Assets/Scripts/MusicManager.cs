using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource AudioSource => audioSource;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if(Instance is null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
