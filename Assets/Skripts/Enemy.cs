using UnityEngine;

public class Enemy : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _currentDirection;

    public float Speed
    {
        get => _speed;
        set => _speed = Mathf.Max(0, value);
    }

    private void Update()
    {
        if (_currentDirection != Vector3.zero)
            Move(_currentDirection);
    }

    public void Move(Vector3 direction)
    {
        _currentDirection = direction.normalized;
        transform.position += _currentDirection * _speed * Time.deltaTime;
        transform.forward = _currentDirection;
    }
}
