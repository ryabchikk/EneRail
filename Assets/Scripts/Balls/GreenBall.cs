using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : EnergyBall, ISingleShotBall
{
    [SerializeField] private bool isSingleShot = true;
    protected override BallType SelfType => BallType.Green;

    protected override int GetEnergyChange()
    {
        return energyChange;
    }

    public bool ShouldDestroy()
    {
        return isSingleShot;
    }
}
