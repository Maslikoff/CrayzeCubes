using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class ClikedCube : MonoBehaviour
{
    [SerializeField] private int _minCountSpawnCube = 2;
    [SerializeField] private int _maxCountSpawnCube = 6;
    [SerializeField] private int _scaleDifference = 2;
    [SerializeField] private int _splitDiffernce = 2;
    [SerializeField] private float _spawnRadius = 0.5f;

    public static event Action<ClikedCube> OnCubeClicked;
    public static event Action<ClikedCube, ClikedCube[]> OnCubeSplit;

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public float SplitChance { get; set; } = 1f;
    public int Generation { get; set; } = 0;

    public void Initialize(int generation, float splitChance)
    {
        Generation = generation;
        SplitChance = splitChance;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();

        SetRandomColor();
    }

    private void OnMouseDown()
    {
        OnCubeClicked?.Invoke(this);
    }

    private void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void TrySplit(Spawner spawner)
    {
        bool shouldSplit = Random.value <= SplitChance;

        if (shouldSplit)
            Split(spawner);

        Destroy(gameObject);
    }

    private void Split(Spawner spawner)
    {
        int newCubesCount = Random.Range(_minCountSpawnCube, _maxCountSpawnCube + 1);

        Vector3 newScale = transform.localScale / _scaleDifference;
        float newSlitChance = SplitChance / _splitDiffernce;
        int newGeneration = Generation + 1;

        ClikedCube[] newCubes = spawner.SpawnCubes(
                transform.position,
                newScale,
                newGeneration,
                newSlitChance,
                newCubesCount,
                _spawnRadius
            );

        OnCubeSplit?.Invoke(this, newCubes);
    }

    public void ApplyExplosionForce(float force, Vector3 explosionPosition, float radius)
    {
        _rigidbody.AddExplosionForce(force, explosionPosition, radius);
    }
}