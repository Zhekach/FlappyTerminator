using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

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

    private void HandleCollision(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            Debug.Log("Ground");
        }
        else if (interactable is Obstacle)
        {
            Debug.Log("Obstacle");
        }
    }
}
