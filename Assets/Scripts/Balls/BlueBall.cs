using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : BaseBall
{
    [SerializeField] private Player player;
    [SerializeField] private Direction direction;
    protected override BallType SelfType => BallType.Blue;

    protected override void Act()
    {
        player.Interrupt();
        Debug.Log(player.controls.LastDirection);
        Debug.Log(direction);
        var target = player.GetTargetAt(direction.ToVector());
        player.MoveTo(target);
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public static class DirectionExtensions
{
    public static Vector3 ToVector(this Direction dir)
    {
        return dir switch
        {
            Direction.Up => Vector3.forward,
            Direction.Down => Vector3.down,
            Direction.Left => Vector3.left,
            Direction.Right => Vector3.right
        };
    }
}