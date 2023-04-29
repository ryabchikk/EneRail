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
    [SerializeField] private float movementCost;
    [SerializeField] private EnergyBar energy;
    private bool _isMoving;
    private Transform _current;

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        var direction = _current.position - transform.position;
        direction = speed * Time.deltaTime * direction.normalized;
        transform.Translate(direction, Space.World);
        energy.ChangeValue(-direction.magnitude);

        if ((transform.position - _current.position).sqrMagnitude <= speed / 100)
        {
            transform.position = _current.position;
            Interrupt();
            
        }
    }
    
    public void MoveTo(Transform target)
    {
        _isMoving = true;
        _current = target;
    }

    public void Interrupt()
    {
        _isMoving = false;
        _current = null;
    }
    
    public Transform GetTargetAt(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position + direction, direction, out var hit, float.PositiveInfinity, ~6) || !hit.collider.gameObject.CompareTag("Target")) 
            return null;
            
        return hit.transform;
    }
}
