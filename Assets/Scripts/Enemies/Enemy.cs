using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IPoolable
{
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private Health _health;
    
    private Pool<Enemy> _pool;

    public event Action Despawned;
    
    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
        _health = GetComponent<Health>();
    }

    public void Initialize(Pool<Enemy> enemiesPool, Pool<Bullet> bulletsPool)
    {
        _pool = enemiesPool;
        _shooter.Initialize(bulletsPool);
    }
    
    public void OnSpawn()
    {
        _health.Died += OnDied;
        _shooter.Activate();
    }

    public void OnDespawn()
    {
        _health.Died -= OnDied;
        _shooter.Deactivate();
    }

    private void OnDied(IKillSource killer)
    {
        _pool.Release(this);
        Despawned?.Invoke();
    }
}