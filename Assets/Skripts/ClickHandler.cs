using UnityEngine;

public class ClickHandler : MonoBehaviour 
{
    [SerializeField] private LayerMask _clickableLayer;

    private CubeEventSystem _cubeEvents;
    private Camera _mainCamera;

    private void Awake()
    {
        _cubeEvents = GetComponent<CubeEventSystem>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleClick();
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _clickableLayer))
            if (hit.collider.TryGetComponent(out ClickedCube cube))
                _cubeEvents.TriggerCubeClicked(cube);
    }
}