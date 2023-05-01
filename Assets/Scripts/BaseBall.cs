using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class BaseBall : MonoBehaviour
{
    [SerializeField] protected BallType type;
    [SerializeField] protected AudioSource pickupSound;
    protected virtual BallType SelfType => BallType.None;
    
    private void Awake()
    {
        type = SelfType;
    }
    
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
#if UNITY_EDITOR
        EditorApplication.delayCall += () => DestroyImmediate(this);
#else
    Destroy(this);
#endif
    }
    
    protected virtual void Act()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        Act();
        pickupSound.Play();
        
        
        if(this is ISingleShotBall singleShot && singleShot.ShouldDestroy())
            Destroy(gameObject);
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
    Blue,
    Finish
}