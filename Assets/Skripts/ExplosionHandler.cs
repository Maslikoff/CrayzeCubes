using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardsModifier = 0.5f;

    public void ApplyExplosionForce(Vector3 explosionCenter, Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(
                    _explosionForce,
                    explosionCenter,
                    _explosionRadius,
                    _upwardsModifier,
                    ForceMode.Impulse
                );
            }
        }
    }
}