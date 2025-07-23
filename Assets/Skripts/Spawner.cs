using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ClickedCube _cubePrefab;
    [SerializeField] private int _initialCubeCount = 5;
    [SerializeField] private float _spawnRadius = 0.5f;
    [SerializeField, Min(2)] private int _minSpawnCount = 2;
    [SerializeField, Min(3)] private int _maxSpawnCount = 6;
    [SerializeField, Min(2)] private int _scaleDivider = 2;
    [SerializeField, Min(2)] private int _splitChanceDivider = 2;

    private CubeEventSystem _cubeEvents;
    private List<ClickedCube> _activeCubes = new List<ClickedCube>();

    private void Awake()
    {
        _cubeEvents = GetComponent<CubeEventSystem>();
        _cubeEvents.OnCubeClicked += OnCubeClicked;
        _cubeEvents.OnCubeSplit += OnCubesSpawned;
    }

    private void Start() => SpawnInitialCubes(_initialCubeCount);

    private ClickedCube InstantiateCube(Vector3 position, Vector3 scale, int generation, float splitChance)
    {
        ClickedCube cube = Instantiate(_cubePrefab, position, Quaternion.identity);
        cube.transform.localScale = scale;
        cube.Initialize(generation, splitChance);
        _activeCubes.Add(cube);
        return cube;
    }

    public void SpawnInitialCubes(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = transform.position + Random.insideUnitSphere * _spawnRadius;
            InstantiateCube(pos, Vector3.one, 0, 1f);
        }
    }

    private bool ShouldSplit(ClickedCube cube) => Random.value <= cube.SplitChance;

    public ClickedCube[] SplitCube(ClickedCube original)
    {
        int count = Random.Range(_minSpawnCount, _maxSpawnCount + 1);
        ClickedCube[] newCubes = new ClickedCube[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPos = original.transform.position + Random.insideUnitSphere * _spawnRadius;
            newCubes[i] = InstantiateCube(
                spawnPos,
                original.transform.localScale / _scaleDivider,
                original.Generation + 1,
                original.SplitChance / _splitChanceDivider
            );
        }

        return newCubes;
    }

    private void OnCubeClicked(ClickedCube cube)
    {
        if (ShouldSplit(cube))
        {
            var newCubes = SplitCube(cube);
            _cubeEvents.TriggerCubeSplit(cube, newCubes);
        }

        _activeCubes.Remove(cube);
        Destroy(cube.gameObject);
    }

    private void OnCubesSpawned(ClickedCube original, ClickedCube[] newCubes)
    {
        // Можно добавить дополнительную логику при spawnе новых кубов
    }

    private void OnDestroy()
    {
        _cubeEvents.OnCubeClicked -= OnCubeClicked;
        _cubeEvents.OnCubeSplit -= OnCubesSpawned;
    }
}