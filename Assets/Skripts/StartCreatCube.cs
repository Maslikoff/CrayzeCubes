using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCreatCube : MonoBehaviour
{
    [SerializeField] private CubeFactory _cubeFactory;

    [Header("Creat First Cube")]
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3 _scale;
    [SerializeField] private Color _color;
    [SerializeField] private float _splitChance;

    private void Start()
    {
        _cubeFactory.CreateCube(_position, _scale, _color, _splitChance);
    }
}
