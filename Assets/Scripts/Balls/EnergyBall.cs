using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BaseBall
{
    [SerializeField] private EnergyBar energy;
    [SerializeField] protected int energyChange;
    [SerializeField] private GameObject pickUpSound;
    protected override void Act()
    {
        var peremennai=Instantiate(pickUpSound);
        
        peremennai.GetComponent<SoundPrefab>().sound.clip= _pickupSound.clip;
        
        energy.ChangeValue(GetEnergyChange());
    }

    protected virtual int GetEnergyChange()
    {
        throw new NotImplementedException();
    }
}
