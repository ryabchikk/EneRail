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
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource movingSound;
    [SerializeField] private Transform startPosition;
    private Vector3 _currentDirection => transform.position - _current.position;
    private Transform _current;
    private Transform particlesTransform;

    private void Awake()
    {
        particlesTransform = particles.transform;
    }

    private void FixedUpdate()
    {
        if (!IsMoving) return;

        var direction = _current.position - transform.position;
        direction = speed * Time.deltaTime * direction.normalized;
        transform.Translate(direction, Space.World);

        if (_currentDirection.sqrMagnitude <= speed / 100)
        {
            transform.position = _current.position;
            Interrupt();
        }
    }
    
    public void MoveTo(Transform target)
    {
        IsMoving = true;
        _current = target;
        particlesTransform.rotation = Quaternion.FromToRotation(transform.forward, _currentDirection);
        particles.Play();
        movingSound.Play();
    }

    public void Interrupt()
    {
        IsMoving = false;
        _current = null;
        particles.Stop();
        movingSound.Stop();
    }
    
    public Transform GetTargetAt(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position + direction, direction, out var hit, float.PositiveInfinity, 1 << 7)
            || !hit.collider.gameObject.CompareTag("Target")) 
            return null;
            
        return hit.transform;
    }
}
