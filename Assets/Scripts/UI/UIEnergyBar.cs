using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIEnergyBar : MonoBehaviour
{
    [SerializeField] private EnergyBar energyBar;
    [SerializeField] private Text energyText;

    private void Start()
    {
        energyText.text = energyBar.Value.ToString();
        energyBar.ValueChanged += UpdateBar;
    }

    private void UpdateBar(int value)
    {
        energyText.text= value.ToString();
    }
}
