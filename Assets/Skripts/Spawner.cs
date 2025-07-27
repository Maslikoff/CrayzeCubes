using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private bool _isSpawning = true;

    private void Start()
    {
        if (_spawnPoints.Count == 0)
        {
            Debug.LogWarning("Точки спавна не назначены! Отключение спаунера.");
            enabled = false;
            return;
        }

        StartCoroutine(SpawnEnemiesRoutine());
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        yield return new WaitForSeconds(1);

        while (_isSpawning)
        {
            SpawnEnemyAtRandomPoint();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnEnemyAtRandomPoint()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Count);
        _spawnPoints[randomIndex].SpawnEnemy();
    }
}
