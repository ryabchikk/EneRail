using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public bool IsMoving { get; private set; }

    public PlayerControls controls;
    
    [SerializeField] private float speed;
    [SerializeField] private EnergyBar energy;
    private Transform _current;

    private void FixedUpdate()
    {
        if (!IsMoving) return;
        Debug.Log(_current.name);

        var direction = _current.position - transform.position;
        direction = speed * Time.deltaTime * direction.normalized;
        transform.Translate(direction, Space.World);
        energy.ChangeValue(1);

        if ((transform.position - _current.position).sqrMagnitude <= speed / 100)
        {
            transform.position = _current.position;
            Interrupt();
            
        }
    }
    
    public void MoveTo(Transform target)
    {
        IsMoving = true;
        _current = target;
    }

    public void Interrupt()
    {
        IsMoving = false;
        _current = null;
    }
    
    public Transform GetTargetAt(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position + direction, direction, out var hit, float.PositiveInfinity, 1 << 7)
            || !hit.collider.gameObject.CompareTag("Target")) 
            return null;
            
        return hit.transform;
    }
}
