using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerShooter _shooter;

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
            Debug.Log("Ground");
    }
}