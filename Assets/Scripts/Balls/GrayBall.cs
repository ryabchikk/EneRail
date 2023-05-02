using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayBall : BaseBall
{
    [SerializeField] private List<BallPair> affectedBalls;
    protected override BallType SelfType => BallType.Gray;

    protected override void Act()
    {
        foreach (var (first, second) in affectedBalls)
        {
            if (second.gameObject.activeSelf) {
                first.gameObject.SetActive(true);
                second.gameObject.SetActive(false);
            }
            else {
                first.gameObject.SetActive(false);
                second.gameObject.SetActive(true);
            }
        }
    }
}

[Serializable]
public struct BallPair
{
    public BaseBall first;
    public BaseBall second;

    public void Deconstruct(out BaseBall first, out BaseBall second)
    {
        first = this.first;
        second = this.second;
    }
}