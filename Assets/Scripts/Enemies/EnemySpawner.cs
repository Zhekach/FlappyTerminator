using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyPoint> _points;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Enemy _enemyPrefab;
    
    private Pool<Enemy> _enemiesPool;
    private BulletsSpawner _bulletsSpawner;
    private OutOfBoundsDetector _outOfBoundsDetector;
    
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

    public void Initialize(BulletsSpawner bulletsSpawner, OutOfBoundsDetector outOfBoundsDetector)
    {
        _bulletsSpawner = bulletsSpawner;
        _outOfBoundsDetector = outOfBoundsDetector;
        _outOfBoundsDetector.DetectedEnemy += OnEnemyOutOfBorders;
    }

    private void TrySpawn()
    {
        var point = GetRandomPoint();

        if (point == null)
            return;
        
        Spawn(point);
        _timer = 0f;
    }

    private void Spawn(EnemyPoint point)
    {
        Enemy enemy = _enemiesPool.Get();
        enemy.Initialize(_bulletsSpawner);
        point.SetEnemy(enemy);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _enemiesPool.Release(enemy);
        EnemyKilled?.Invoke();
    }

    private void OnEnemyOutOfBorders(Enemy enemy)
    {
        _enemiesPool.Release(enemy);
    }

    private EnemyPoint GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _points.Count);
        EnemyPoint result = _points[randomIndex];
        
        return result;
    }
}