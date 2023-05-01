using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    [SerializeField] private EnergyBar energy;
    [SerializeField] private GameObject finishPanel;

    private void Awake()
    {
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
        Time.timeScale= 1.0f;
    }

    public void Finish()
    {
        finishPanel.SetActive(true);
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
}
