using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerKillsCounter))]
[RequireComponent(typeof(Weapon))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerKillsCounter _killsCounter;
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private Weapon _weapon;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _killsCounter = GetComponent<PlayerKillsCounter>();
        _weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += HandleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= HandleCollision;
    }

    public void Initialize(Pool<Bullet> bulletsPool)
    {
        _weapon.Initialize(bulletsPool, _shooter.BulletSpeed, _shooter.BulletDamage, _shooter);
    }

    public void Reset()
    {
        _mover.Reset();
        _killsCounter.Reset();
    }

    private void HandleCollision(IInteractable interactable)
    {
        if (interactable is Ground)
            Debug.Log("Ground");
    }
}