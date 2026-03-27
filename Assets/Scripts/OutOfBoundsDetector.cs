using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OutOfBoundsDetector : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    public event Action<Enemy> DetectedEnemy;
    public event Action<Bullet> DetectedBullet;
    
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Enemy out of borders");
            DetectedEnemy?.Invoke(enemy);
        }
        
        if (other.TryGetComponent(out Bullet bullet))
            DetectedBullet?.Invoke(bullet);
    }
}
