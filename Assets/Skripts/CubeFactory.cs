using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _defferenceCube = 2f;

    public CubeController CreateCube(Vector3 positions, Vector3 scale, Color color, float splitChance)
    {
        GameObject cube = Instantiate(_cubePrefab, positions, Quaternion.identity);
        cube.transform.localScale = scale;

        CubeController cubeController = cube.GetComponent<CubeController>();
        cubeController.Initialize(color, splitChance);

        return cubeController;
    }

    public List<CubeController> CreateSplitCubes(Cube cube, int count)
    {
        List<CubeController> newCubes = new List<CubeController>();

        for (int i = 0; i < count; i++)
        {
            Color reandomColor = new Color(Random.value, Random.value, Random.value);
            CubeController newCube = CreateCube(cube.Position, cube.Scale / _defferenceCube, reandomColor, cube.SplitChance / _defferenceCube);

            newCubes.Add(newCube);
        }

        return newCubes;
    }
}
