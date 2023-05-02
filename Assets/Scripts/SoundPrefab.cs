using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPrefab : MonoBehaviour
{
    public AudioSource sound;
    void Update()
    {
        if (!sound.isPlaying) { 
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        sound.Play();
    }
}
