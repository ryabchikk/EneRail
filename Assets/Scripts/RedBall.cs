using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : EnergyBall
{
    protected override BallType SelfType => BallType.Red;

    protected override float GetEnergyChange()
    {
        return -energyChange;
    }
}
