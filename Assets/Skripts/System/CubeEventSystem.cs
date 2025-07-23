using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEventSystem : MonoBehaviour
{
    public event Action<ClickedCube> OnCubeClicked;
    public event Action<ClickedCube, ClickedCube[]> OnCubeSplit;

    public void TriggerCubeClicked(ClickedCube cube)
    {
        OnCubeClicked?.Invoke(cube);
    }

    public void TriggerCubeSplit(ClickedCube original, ClickedCube[] newCubes)
    {
        OnCubeSplit?.Invoke(original, newCubes);
    }
}