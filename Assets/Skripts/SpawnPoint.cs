using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Vector3 _spawnDirection = Vector3.forward;

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemy.TryGetComponent<IMovable>(out var movable))
            movable.Move(_spawnDirection.normalized);
    }
}
