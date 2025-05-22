using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour, IExplosionHandler
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField][Range(0.1f, 2f)] private float _explosionChaotic = 0.5f;

    public void HandleExplosion(List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            var rigidbody = cube.GetComponent<Rigidbody>();

            Vector3 explosionPos = cube.transform.position + Random.insideUnitSphere * _explosionChaotic;

            rigidbody.AddExplosionForce(_explosionForce, explosionPos, _explosionRadius);
        }
    }
}
