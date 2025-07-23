using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 0.5f;

    private CubeEventSystem _cubeEvents;

    private void Awake()
    {
        _cubeEvents = GetComponent<CubeEventSystem>();

        _cubeEvents.OnCubeSplit += OnCubeSplit;
    }

    private void OnCubeSplit(ClickedCube original, ClickedCube[] newCubes)
    {
        foreach (ClickedCube cube in newCubes)
        {
            Vector3 direction = (cube.transform.position - original.transform.position).normalized;
            float distance = Vector3.Distance(cube.transform.position, original.transform.position);
            float force = _explosionForce * (1 - Mathf.Clamp01(distance / _explosionRadius));
            cube.ApplyForce(direction * force + Vector3.up * _upwardModifier);
        }
    }

    private void OnDestroy()
    {
        _cubeEvents.OnCubeSplit -= OnCubeSplit;
    }
}