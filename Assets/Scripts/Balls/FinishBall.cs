using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBall : BaseBall
{
    protected override BallType SelfType => BallType.Finish;
    protected override void Act()
    {
        GlobalManager.Instance.Finish();
    }
}
