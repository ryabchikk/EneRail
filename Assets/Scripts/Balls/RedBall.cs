using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBall : EnergyBall, ISingleShotBall
{
    [SerializeField] private bool isSingleShot = true;
    protected override BallType SelfType => BallType.Red;

    protected override int GetEnergyChange()
    {
        return -energyChange;
    }
    
    public bool ShouldDestroy()
    {
        return isSingleShot;
    }
}
