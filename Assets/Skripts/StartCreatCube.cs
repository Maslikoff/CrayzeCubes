using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreatCube : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeExploder _exploder;

    private void Awake()
    {
        _spawner.Initialize(_exploder);
    }
}
