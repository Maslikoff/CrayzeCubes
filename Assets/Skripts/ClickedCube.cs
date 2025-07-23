using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class ClickedCube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public float SplitChance { get; private set; }
    public int Generation { get; private set; }

    public void Initialize(int generation, float splitChance)
    {
        Generation = generation;
        SplitChance = splitChance;
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        _renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    public void ApplyForce(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}