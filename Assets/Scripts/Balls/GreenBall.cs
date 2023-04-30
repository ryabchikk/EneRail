using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBall : EnergyBall
{
    protected override BallType SelfType => BallType.Green;

    protected override float GetEnergyChange()
    {
        return energyChange;
    }
}
