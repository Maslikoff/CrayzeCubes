using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private bool _isLooping = true;

    private int _currentPointIndex;
    private Vector3 _currentDirection;

    public Vector3 Position => transform.position;

    private void Start()
    {
        if (_points.Length > 0)
            transform.position = _points[0].position;

        UpdateDirection();
    }

    private void Update()
    {
        transform.position += _currentDirection * _speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _points[_currentPointIndex].position) < 0.1f)
            MoveToNextWaypoint();
    }

    private void MoveToNextWaypoint()
    {
        if (_currentPointIndex >= _points.Length - 1)
        {
            if (_isLooping)
                _currentPointIndex = 0;
            else
                return;
        }
        else
        {
            _currentPointIndex++;
        }

        UpdateDirection();
    }

    private void UpdateDirection()
    {
        _currentDirection = (_points[_currentPointIndex].position - transform.position).normalized;
    }
}
