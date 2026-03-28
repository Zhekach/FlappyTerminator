using System;
using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    [SerializeField] private int _scoresPerEnemyKill = 2;
    [SerializeField] private int _scoresPerEnemyPass = 1;
    
    private int _scoresCount;
    private EnemySpawner _enemySpawner;
    
    public event Action<int> ScoresCountChanged;

    private void OnDisable()
    {
        _enemySpawner.EnemyKilled -= OnEnemyKilled;
    }
    
    public void Initialize(EnemySpawner spawner)
    {
        _enemySpawner = spawner;
        _enemySpawner.EnemyKilled += OnEnemyKilled;
        _enemySpawner.EnemyPassed += OnEnemyPassed;
    }

    public void Reset()
    {
        _scoresCount = 0;
        ScoresCountChanged?.Invoke(_scoresCount);
    }

    private void OnEnemyKilled()
    {
        _scoresCount += _scoresPerEnemyKill;
        ScoresCountChanged?.Invoke(_scoresCount);
    }

    private void OnEnemyPassed()
    {
        _scoresCount += _scoresPerEnemyPass;
        ScoresCountChanged?.Invoke(_scoresCount);
    }
}
