using UnityEngine;

public class StartCreatCube : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    private Spawner _spawner;
    private ExplosionHandler _explosionHandler;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _explosionHandler = new ExplosionHandler(_explosionForce, _explosionRadius);

        ClikedCube.OnCubeSplit += HandleCubeSplit;
    }

    private void OnDestroy()
    {
        ClikedCube.OnCubeSplit -= HandleCubeSplit;
    }

    private void HandleCubeSplit(ClikedCube originalCube, ClikedCube[] newCubes)
    {
        _explosionHandler.HandleExplosion(originalCube.transform.position, newCubes);
    }
}