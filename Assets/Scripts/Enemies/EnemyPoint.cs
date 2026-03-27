using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    private Enemy _currentEnemy;

    public bool IsEmpty() => _currentEnemy == null;

    public void SetEnemy(Enemy enemy)
    {
        if (_currentEnemy != null)
        {
            Debug.LogError("Point already occupied");
            return;
        }

        _currentEnemy = enemy;
        //_currentEnemy.transform.SetParent(transform);
        _currentEnemy.transform.localPosition = transform.position;
        _currentEnemy.Activate();
        _currentEnemy.Despawned += OnEnemyDespawned;
    }

    private void OnEnemyDespawned()
    {
        _currentEnemy.Deactivate();
        _currentEnemy.Despawned -= OnEnemyDespawned;
        _currentEnemy = null;
    }

    private void OnDisable()
    {
        if (_currentEnemy != null)
        {
            _currentEnemy.Deactivate();
            _currentEnemy.Despawned -= OnEnemyDespawned;
            _currentEnemy = null;
        }
    }
}