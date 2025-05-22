using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnAreaSize = 10f;
    [SerializeField] private int _initialCubesCount = 5;

    private CubeFactory _cubeFactory;
    private CubeSplit _cubeSplit;
    private IExplosionHandler _explosionHandler;
    private List<Cube> _spawnedCubes = new List<Cube>();

    public void Initialize(IExplosionHandler explosionHandler)
    {
        _cubeFactory = GetComponent<CubeFactory>();
        _cubeSplit = GetComponent<CubeSplit>();
        _explosionHandler = explosionHandler;
    }

    private void Start()
    {
        SpawnInitialCubes();
    }

    private void SpawnInitialCubes()
    {
        for (int i = 0; i < _initialCubesCount; i++)
        {
            SpawnCube(GetRandomSpawnPosition(), 1f);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(-_spawnAreaSize, _spawnAreaSize),
            Random.Range(1f, _spawnAreaSize),
            Random.Range(-_spawnAreaSize, _spawnAreaSize)
        );
    }

    public void HandleCubeClick(Cube cube)
    {
        cube.OnCubeClicked += OnCubeClickedHandler;

        if (_cubeSplit.ShouldSplit())
        {
            var newCubes = SpawnCubesFrom(cube, _cubeSplit.GetSplitCount());
            _explosionHandler?.HandleExplosion(newCubes);
        }

        DestroyCube(cube);
    }

    private List<Cube> SpawnCubesFrom(Cube originalCube, int count)
    {
        var newCubes = new List<Cube>();
        Vector3 spawnPosition = originalCube.transform.position;

        for (int i = 0; i < count; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * 1.5f;
            newCubes.Add(SpawnCube(spawnPosition + randomOffset,
                              originalCube.transform.localScale.x / 2f));
        }

        return newCubes;
    }

    private Cube SpawnCube(Vector3 position, float scale)
    {
        var cube = _cubeFactory.CreateCube(position, scale);
        cube.OnCubeClicked += HandleCubeClick;
        _spawnedCubes.Add(cube);
        return cube;
    }

    private void DestroyCube(Cube cube)
    {
        if (_spawnedCubes.Contains(cube))
        {
            cube.OnCubeClicked -= HandleCubeClick;
            cube.OnCubeClicked -= OnCubeClickedHandler;
            _spawnedCubes.Remove(cube);
            Destroy(cube.gameObject);
        }
    }

    private void OnCubeClickedHandler(Cube cube)
    {
        cube.OnCubeClicked -= OnCubeClickedHandler;
    }
}
