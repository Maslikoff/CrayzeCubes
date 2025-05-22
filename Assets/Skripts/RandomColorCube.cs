using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorCube : MonoBehaviour
{
    public Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
