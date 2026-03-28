using System;
using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IPoolable, IInteractable
{
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private Health _health;
    
    public event Action<Enemy> Died;
    
    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
        _health = GetComponent<Health>();
    }

    public void Initialize(BulletsSpawner bulletsSpawner)
    {
        _shooter.Initialize(bulletsSpawner);
    }
    
    public void OnSpawn()
    {
        _health.Died += OnDied;
    }

    public void OnDespawn()
    {
        _health.Died -= OnDied;
    }

    public void Activate()
    {
        _shooter.Activate();
    }

    private void OnDied()
    {
        Died?.Invoke(this);
    }
}