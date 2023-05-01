using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayBall : BaseBall
{
    [SerializeField] private List<BallColorPair> affectedBalls;
    protected override BallType SelfType => BallType.Gray;

    protected override void Act()
    {
        foreach (var (ball, color) in affectedBalls)
            ball.ChangeType(color);
    }
}

[Serializable]
public struct BallColorPair
{
    public BaseBall ball;
    public BallType type;
    public void Deconstruct(out BaseBall ball, out BallType type)
    {
        ball = this.ball;
        type = this.type;
    }
}