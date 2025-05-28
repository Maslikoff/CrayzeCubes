using UnityEngine;

public class ClickHandler : MonoBehaviour 
{
    [SerializeField] private LayerMask _clickableLayer;

    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _clickableLayer))
            {
                ClikedCube cube = hit.collider.GetComponent<ClikedCube>();
                cube.TrySplit(_spawner);
            }
        }
    }
}