using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPoint> _points;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Enemy _enemyPrefab;

    private Pool<Enemy> _enemiesPool;
    private Pool<Bullet> _bulletsPool;
    private float _timer;

    public event Action EnemyKilled;
    
    private void Awake()
    {
        _enemiesPool = new Pool<Enemy>(_enemyPrefab);
        _enemiesPool.Initialize();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < _spawnDelay)
            return;

        _timer = 0f;

        TrySpawn();
    }

    public void Initialize(Pool<Bullet> bulletsPool)
    {
        _bulletsPool = bulletsPool;
    }

    private void TrySpawn()
    {
        var freePoint = GetFreePoint();

        if (freePoint == null)
            return;

        Enemy enemy = _enemiesPool.Get();
        enemy.Initialize(_enemiesPool, _bulletsPool);
        freePoint.SetEnemy(enemy);
        _timer = 0f;
    }

    private EnemyPoint GetFreePoint()
    {
        foreach (var point in _points)
        {
            if (point.IsEmpty())
                return point;
        }

        return null;
    }
}