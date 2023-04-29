using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public bool IsMoving => _isMoving;
    
    [SerializeField] private float speed;
    private bool _isMoving;
    private Transform _current;

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        var direction = _current.position - transform.position;
        transform.Translate(speed * Time.deltaTime * direction.normalized, Space.World);

        if ((transform.position - _current.position).sqrMagnitude <= 0.01f)
        {
            _isMoving = false;
        }
    }
    
    public void Move(Transform target)
    {
        _isMoving = true;
        _current = target;
    }
}
