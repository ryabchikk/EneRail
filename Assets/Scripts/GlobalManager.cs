using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    [SerializeField] private EnergyBar energy;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        var audioSource = MusicManager.Instance.AudioSource;
        if(clip != null && audioSource.clip != clip) { 
            audioSource.clip = clip;
            audioSource.Play();
        }
            
        Instance = this;
        energy.NoEnergy += GameOver;
        StartGame();
    }

    public void GameOver()
    {
        Restart();
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
    }

    public void Finish()
    {
        finishPanel.SetActive(true);
        SaveCurrentLevel();
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        energy.NoEnergy -= GameOver;
    }

    private void SaveCurrentLevel()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        var regex = new Regex("[0-9]+");
        var level = int.Parse(regex.Match(sceneName).Value);
        PlayerPrefs.SetInt("AvailableLevel", level + 1);
        if (!PlayerPrefs.HasKey(level.ToString()))
        {
            PlayerPrefs.SetInt(level.ToString(), 0);
            FileEncoder.AddOpenPositions(FileEncoder.GeneratePositionsToOpen(5));
        }
    }
}
