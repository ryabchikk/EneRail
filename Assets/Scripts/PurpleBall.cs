using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBall : BaseBall
{
    [SerializeField] private PurpleBall boundBall;
    [SerializeField] private Player player;
    private bool _teleported;
    protected override BallType SelfType => BallType.Purple;

    protected override void Act()
    {
        if (_teleported) 
            return;
        
        boundBall._teleported = true;
        player.transform.position = boundBall.transform.position;
        player.Interrupt();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _teleported = false;
        }
    }
}
