using UnityEngine;

public class ExplosionHandler
{
    private readonly float _force;
    private readonly float _radius;

    public ExplosionHandler(float force, float radius)
    {
        _force = force;
        _radius = radius;
    }

    public void HandleExplosion(Vector3 position, ClikedCube[] cubes)
    {
        foreach (ClikedCube cube in cubes)
        {
            cube.ApplyExplosionForce(_force, position, _radius);
        }
    }
}