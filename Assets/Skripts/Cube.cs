using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public float SplitChance { get; private set; }
    public float CurrentScale => transform.localScale.x;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(float splitChance)
    {
        SplitChance = splitChance;
        _renderer.material.color = Random.ColorHSV();
    }
}