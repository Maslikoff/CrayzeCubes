using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private MovingTarget _target;

    public Enemy SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemy.TryGetComponent<Enemy>(out Enemy enemyComponent))
            enemyComponent.Initialize(_target);
        else
            Debug.LogError("��������� ��������� �����������!", enemy);

        return enemy;
    }
}
