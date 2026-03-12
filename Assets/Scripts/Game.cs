using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Bullet _bulletPrefab;
    
    private BulletsPool _bulletsPool;

    private void Awake()
    {
        if (_player == null)
            Debug.LogError($"{gameObject.name}: _player reference is null");
        
        if (_enemySpawner == null)
            Debug.LogError($"{gameObject.name}: _enemyGenerator reference is null");
        
        if(_bulletPrefab == null)
            Debug.LogError($"{gameObject.name}: bulletPrefab is null");
        
        _bulletsPool = new BulletsPool(_bulletPrefab);
        _bulletsPool.Initialize();
        
        _player.Initialize(_bulletsPool);
    }

}