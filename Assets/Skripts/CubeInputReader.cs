using System;
using UnityEngine;

public class CubeInputReader : MonoBehaviour 
{
    public event Action<Cube> OnCubeClicked;

    [SerializeField] private LayerMask _clickableLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleClick();
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, _clickableLayer))
            if (hit.collider.TryGetComponent(out Cube cube))
                OnCubeClicked?.Invoke(cube);
    }
}