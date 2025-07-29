using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private bool _isSpawning = true;

    private WaitForSeconds _spawnWait;
    private Coroutine _spawnRoutine;

    private void Awake()
    {
        _spawnWait = new WaitForSeconds(_spawnInterval);

        if (_spawnPoints.Length == 0)
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (_spawnRoutine == null)
            _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(1);

        while (_isSpawning)
        {
            var randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            randomPoint.SpawnEnemy();
            yield return _spawnWait;
        }
    }
}
