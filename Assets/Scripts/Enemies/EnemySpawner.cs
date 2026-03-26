using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPoint> _points;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Enemy _enemyPrefab;

    private Pool<Enemy> _pool;

    private void Awake()
    {
        _pool = new Pool<Enemy>(_enemyPrefab);
    }

    //TODO добавить сюда таймер
    private void Update()
    {
        foreach (var point in _points)
        {
            if (point.IsEmpty())
                point.SetEnemy(_pool.Get());
        }
    }
    
    
}