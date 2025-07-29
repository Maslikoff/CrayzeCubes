using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Vector3 _spawnDirection = Vector3.forward;

    public Enemy SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemy.TryGetComponent<Enemy>(out Enemy enemyComponent))
            enemyComponent.Initialize(_spawnDirection);
        else
            Debug.LogError("Вражеский компонент отсутствует!", enemy);

        return enemy;
    }
}
