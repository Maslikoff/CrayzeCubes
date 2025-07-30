using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private MovingTarget _target;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (_target.Position - transform.position).normalized;

        _rigidbody.velocity = direction * _speed;

        LookAtTarget();
    }

    public void Initialize(float speed, MovingTarget target)
    {
        _speed = Mathf.Max(0, speed);
        _target = target;

        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (_target != null)
            transform.forward = (_target.Position - transform.position).normalized;
    }
}
