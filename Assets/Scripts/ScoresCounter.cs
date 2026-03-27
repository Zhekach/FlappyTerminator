using UnityEngine;

public class ScoresCounter : MonoBehaviour
{
    [SerializeField] private int _scoresPerEnemyKill = 2;
    
    private int _scoresCount;
    private EnemySpawner _enemySpawner;
    
    public int ScoresCount => _scoresCount;

    private void OnDisable()
    {
        _enemySpawner.EnemyKilled -= OnEnemyKilled;
    }
    
    public void Initialize(EnemySpawner spawner)
    {
        _enemySpawner = spawner;
        _enemySpawner.EnemyKilled += OnEnemyKilled;
    }

    public void ResetState()
    {
        _scoresCount = 0;
    }

    private void OnEnemyKilled()
    {
        _scoresCount += _scoresPerEnemyKill;
        
        Debug.Log($"{_scoresCount} scores");
    }
}
