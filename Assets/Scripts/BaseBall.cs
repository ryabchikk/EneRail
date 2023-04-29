using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    [SerializeField] protected BallType type = BallType.None;
    protected virtual BallType SelfType => BallType.None;


    public void ChangeType(BallType newType)
    {
        var typename = newType switch
        {
            BallType.None => "BaseBall",
            _ => $"{type}Ball"
        };
        
        
        var t = Type.GetType(typename);
        var component = gameObject.AddComponent(t) as BaseBall;
        component.type = newType;
        UnityEditor.EditorApplication.delayCall += () => DestroyImmediate(this);
    }
    
    protected virtual void Act()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Act();
    }

    protected virtual void OnValidate()
    {
        if (type == SelfType) 
            return;

        ChangeType(type);
    }
}

public enum BallType
{
    None,
    Green,
    Red,
    Purple,
    Gray,
    Blue
}