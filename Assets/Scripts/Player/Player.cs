using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private Health _health;
    
    public event Action Died;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _shooter = GetComponent<PlayerShooter>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
        _health.Died -= Die;
    }

    public void Initialize(BulletsSpawner bulletsSpawner)
    {
        _shooter.Initialize(bulletsSpawner);
    }

    public void Reset()
    {
        _mover.Reset();
    }

    private void HandleCollision(IInteractable interactable)
    {
        if (interactable is Ground)
            Die();
        if(interactable is Enemy)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}