using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : BaseBall
{
    [SerializeField] private Player player;
    protected override BallType SelfType => BallType.Blue;

    protected override void Act()
    {
        player.Interrupt();
        Debug.Log(player.controls.LastDirection);
        var direction = player.controls.LastDirection * -1;
        Debug.Log(direction);
        var target = player.GetTargetAt(direction);
        player.MoveTo(target);
    }
}
