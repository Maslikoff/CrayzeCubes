using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ClikedCube _cubePrefab;

    public ClikedCube[] SpawnCubes(Vector3 origin, Vector3 scale, int generation, float splitChance, int count, float radius)
    {
        ClikedCube[] newCube = new ClikedCube[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 spawnPosition = origin + Random.insideUnitSphere * radius;

            ClikedCube cube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
            cube.transform.localScale = scale;
            cube.gameObject.layer = LayerMask.NameToLayer("Cube");

            cube.Initialize(generation, splitChance);

            newCube[i] = cube;
        }

        return newCube;
    }
}