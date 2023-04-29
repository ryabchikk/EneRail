using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public float Value => value;
    public event Action<float> ValueChanged;
    public event Action NoEnergy;

    [SerializeField] private float value;

    public void ChangeValue(float val)
    {
        value += val;
        if (value > 100)
            value = 100;

        if (value <= 0)
        {
            value = 0;
            NoEnergy?.Invoke();
        }
        
        ValueChanged?.Invoke(value);
    }

    private void GameOver()
    {
        GlobalManager.Instance.GameOver();
    }
}
