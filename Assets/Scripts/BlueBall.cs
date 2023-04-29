using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : BaseBall
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerControls playerMovement;
    protected override BallType SelfType => BallType.Blue;

    protected override void Act()
    {
        player.Interrupt();
        Debug.Log(playerMovement.LastDirection);
        var direction = playerMovement.LastDirection * -1;
        Debug.Log(direction);
        var target = player.GetTargetAt(direction);
        player.MoveTo(target);
    }
}
