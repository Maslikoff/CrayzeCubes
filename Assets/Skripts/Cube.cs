using UnityEngine;

public class Cube
{
    public Vector3 Position { get; }
    public Vector3 Scale { get; }
    public float SplitChance { get; }

    public Cube(Vector3 position, Vector3 scale, float splitChance)
    {
        Position = position;
        Scale = scale;
        SplitChance = splitChance;
    }
}
