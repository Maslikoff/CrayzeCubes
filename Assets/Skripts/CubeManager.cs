using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public static CubeManager Instance { get; private set; }

    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private int _minCountCube = 2;
    [SerializeField] private int _maxCountCube = 6;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void SplitCube(CubeController originalCube)
    {
        Cube splitCube = originalCube.PrepareSplit();
        originalCube.DestroyCube();

        int newCubeCount = Random.Range(_minCountCube, _maxCountCube + 1);
        List<CubeController> newCubes = _cubeFactory.CreateSplitCubes(splitCube, newCubeCount);

        ApplyExplosionForce(newCubes, splitCube.Position);
    }

    private void ApplyExplosionForce(List<CubeController> cubes, Vector3 explosionOrigin)
    {
        foreach (var cube in cubes)
        {
            cube.ApplyForce(explosionOrigin, _explosionForce, _explosionRadius);
        }
    }
}