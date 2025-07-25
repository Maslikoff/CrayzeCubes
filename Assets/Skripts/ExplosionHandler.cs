using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _baseExplosionForce = 10f;
    [SerializeField] private float _baseExplosionRadius = 5f;
    [SerializeField] private float _upwardsModifier = 0.5f;
    [SerializeField] private AnimationCurve _scaleToForceMultiplier = new AnimationCurve(new Keyframe(0.1f, 2f), new Keyframe(1f, 1f));

    public void ApplyExplosionForce(Vector3 explosionCenter, Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(
                    _baseExplosionForce,
                    explosionCenter,
                    _baseExplosionRadius,
                    _upwardsModifier,
                    ForceMode.Impulse
                );
            }
        }
    }

    public void ExplodeCube(Cube explodingCube)
    {
        float scaleFactor = _scaleToForceMultiplier.Evaluate(explodingCube.transform.localScale.x);
        float explosionForce = _baseExplosionForce * scaleFactor;
        float explosionRadius = _baseExplosionRadius * scaleFactor;

        Vector3 explosionCenter = explodingCube.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionCenter, explosionRadius);

        foreach (var collider in colliders)
            if(collider.TryGetComponent<Cube>(out var cube) && cube != explodingCube)
                ApplyDistanceBasedExplosion(cube, explosionCenter, explosionForce, explosionRadius);
    }

    private void ApplyDistanceBasedExplosion(Cube cube, Vector3 explosionCenter, float force, float radius)
    {
        float distance = Vector3.Distance(cube.transform.position, explosionCenter);
        float distanceFactor = Mathf.Clamp01(1-distance /  radius);
        float finalForce = force * distanceFactor;

        if(cube.TryGetComponent<Rigidbody>(out var rigidbody))
            rigidbody.AddExplosionForce(finalForce, explosionCenter, radius, _upwardsModifier, ForceMode.Impulse);
    }
}