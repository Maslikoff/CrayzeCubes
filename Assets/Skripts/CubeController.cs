using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class CubeController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Renderer _renderer;
    private float _splitChance;

    public float CurrentSplitChance => _splitChance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(Color color, float initialSplitChance)
    {
        _renderer.material.color = color;
        _splitChance = initialSplitChance;
    }

    public Cube PrepareSplit()
    {
        return new Cube(transform.position, transform.localScale, _splitChance);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }

    public void ApplyForce(Vector3 expolosionOrigin, float force, float radius)
    {
        _rigidbody.AddExplosionForce(force, expolosionOrigin, radius);
    }

    private void OnMouseDown()
    {
        bool isShouldSplit = Random.value <= _splitChance;

        if (isShouldSplit)
            CubeManager.Instance.SplitCube(this);
        else
            DestroyCube();
    }
}