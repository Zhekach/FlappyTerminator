using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IInteractable interactable))
        {
            CollisionDetected?.Invoke(interactable);
        }
    }
}