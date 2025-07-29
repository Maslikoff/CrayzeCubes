using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }

    public void Initialize(float speed, Vector3 direction)
    {
        _speed = Mathf.Max(0, speed);
        SetDirection(direction);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        transform.forward = _direction;
    }
}
