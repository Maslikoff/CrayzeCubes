using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 5f;

    public void Initialize(MovingTarget target)
    {
        if(TryGetComponent<EnemyMovement>(out EnemyMovement movement) == false)
            movement = gameObject.AddComponent<EnemyMovement>();

        movement.Initialize(_baseSpeed, target);
    }
}