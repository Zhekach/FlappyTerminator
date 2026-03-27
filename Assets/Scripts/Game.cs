using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private ScoresCounter _scoresCounter;
    
    private Pool<Bullet> _bulletsPool;

    private void Awake()
    {
        if (_player == null)
            Debug.LogError($"{gameObject.name}: _player reference is null");
        
        if (_enemySpawner == null)
            Debug.LogError($"{gameObject.name}: _enemyGenerator reference is null");
        
        if(_bulletPrefab == null)
            Debug.LogError($"{gameObject.name}: bulletPrefab is null");
        
        if (_scoresCounter == null)
            Debug.LogError($"{gameObject.name}: scoresCounter is null");
        
        _bulletsPool = new Pool<Bullet>(_bulletPrefab);
        
        _bulletsPool.Initialize();
        _player.Initialize(_bulletsPool);
        _enemySpawner.Initialize(_bulletsPool);
    }
}