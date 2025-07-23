using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private int _initialCubesCount = 5;
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private Vector2 _spawnCountRange = new Vector2(2, 6);
    [SerializeField] private float _scaleReduction = 2f;

    private void Start()
    {
        SpawnInitialCubes();
    }

    public void SpawnInitialCubes()
    {
        for (int i = 0; i < _initialCubesCount; i++)
        {
            SpawnCube(
                transform.position + Random.insideUnitSphere * _spawnRadius,
                Vector3.one,
                1f
            );
        }
    }

    public Cube[] SpawnChildCubes(Cube originalCube)
    {
        int spawnCount = Random.Range((int)_spawnCountRange.x, (int)_spawnCountRange.y + 1);
        Cube[] newCubes = new Cube[spawnCount];

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPos = originalCube.transform.position + Random.insideUnitSphere * _spawnRadius;

            newCubes[i] = SpawnCube(
                spawnPos,
                originalCube.transform.localScale / _scaleReduction,
                originalCube.SplitChance * 0.5f
            );
        }

        return newCubes;
    }

    private Cube SpawnCube(Vector3 position, Vector3 scale, float splitChance)
    {
        Cube newCube = Instantiate(_cubePrefab, position, Quaternion.identity);
        newCube.transform.localScale = scale;
        newCube.Initialize(splitChance);

        return newCube;
    }

    public void DestroyCube(GameObject cube) => Destroy(cube);
}