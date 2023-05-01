using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
public class BaseBall : MonoBehaviour
{
    [SerializeField] protected BallType type;
    private AudioSource _pickupSound;
    protected virtual BallType SelfType => BallType.None;
    
    private void Awake()
    {
        type = SelfType;
        _pickupSound = GetComponent<AudioSource>();
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
        component.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/" + type + " Bloom");
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
        _pickupSound.Play();
        
        
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