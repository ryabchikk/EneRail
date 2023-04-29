using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    [SerializeField] private EnergyBar energy;

    private void Awake()
    {
        Instance = this;
        energy.NoEnergy += GameOver;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        
    }

    public void Finish()
    {
        
    }

    private void OnDestroy()
    {
        energy.NoEnergy -= GameOver;
    }
}
