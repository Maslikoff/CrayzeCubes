using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefabe;

    private RandomColorCube _cubeColorCube;

    private void Awake()
    {
        _cubeColorCube = GetComponent<RandomColorCube>();
    }

    public Cube CreateCube(Vector3 position, float scale)
    {
        var cube = Instantiate(_cubePrefabe, position, Quaternion.identity);
        cube.transform.localScale = Vector3.one * scale;

        var renderer = cube.GetComponent<Renderer>();
        renderer.material.color = _cubeColorCube.GetRandomColor();

        return cube;
    }
}
