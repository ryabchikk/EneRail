using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : BaseBall
{
    [SerializeField] private EnergyBar energy;
    [SerializeField] protected int energyChange;

    protected override void Act()
    {
        energy.ChangeValue(GetEnergyChange());
    }

    protected virtual int GetEnergyChange()
    {
        throw new NotImplementedException();
    }
}
