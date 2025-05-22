using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSplit : MonoBehaviour
{
    [SerializeField][Range(0f, 1f)] private float _splitProbability = 0.7f;
    [SerializeField] private Vector2Int _splitRange = new Vector2Int(2, 6);

    public bool ShouldSplit()
    {
        return Random.value <= _splitProbability;
    }

    public int GetSplitCount()
    {
        return Random.Range(_splitRange.x, _splitRange.y + 1);
    }
}
