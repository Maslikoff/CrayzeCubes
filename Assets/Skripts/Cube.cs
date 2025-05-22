using UnityEngine;
using System;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour 
{
    public event Action<Cube> OnCubeClicked;

    private void OnMouseDown()
    {
        OnCubeClicked?.Invoke(this);
    }
}
