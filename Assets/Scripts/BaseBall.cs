using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    public enum BallType
    {
        Green,
        Red,
        Purple,
        Gray
    }

    [SerializeField] protected BallType type = BallType.Green;

    private void Update()
    {
        
    }

    protected virtual void OnValidate()
    {
        var t = Type.GetType($"{type}Ball");
        var component = gameObject.AddComponent(t) as BaseBall;
        component.type = type;
        Destroy(this);
    }
}
