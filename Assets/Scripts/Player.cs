using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerKillsCounter))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerKillsCounter _killsCounter;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }
    
    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    public void Reset()
    {
        _mover.Reset();
        _killsCounter.Reset();
    }

    private void HandleCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            Debug.Log("Ground");
        }
        else if (interactable is Bullet)
        {
            Debug.Log("Bullet");
        }
    }
}
