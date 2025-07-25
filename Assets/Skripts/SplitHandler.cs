using UnityEngine;
using Random = UnityEngine.Random;

public class SplitHandler : MonoBehaviour
{
    [SerializeField] private CubeInputReader _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ExplosionHandler _exploder;

    private void Awake()
    {
        _inputReader = GetComponent<CubeInputReader>();
        _spawner = GetComponent<Spawner>();
        _exploder = GetComponent<ExplosionHandler>();

        _inputReader.OnCubeClicked += HandleCubeClick;
    }

    private void HandleCubeClick(Cube cube)
    {
        bool shouldSplit = Random.value <= cube.SplitChance;

        if (shouldSplit)
        {
            Cube[] newCubes = _spawner.SpawnChildCubes(cube);
            _exploder.ApplyExplosionForce(cube.transform.position, newCubes);
        }
        else
        {
            _exploder.ExplodeCube(cube);
        }

        _spawner.DestroyCube(cube.gameObject);
    }

    private void OnDisable()
    {
        _inputReader.OnCubeClicked -= HandleCubeClick;
    }
}