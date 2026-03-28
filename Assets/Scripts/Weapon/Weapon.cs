using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private float _xOffset;

    private Rigidbody2D _rigidbody;
    
    private float _speed;
    private int _damage;
    private BulletsSpawner _bulletsSpawner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletsSpawner bulletsSpawner, float bulletSpeed, int damage)
    {
        _bulletsSpawner = bulletsSpawner;
        _speed = bulletSpeed;
        _damage = damage;
    }

    public void Shoot()
    {
        if (_bulletsSpawner == null)
        {
            Debug.LogError("BulletsSpawner is null! Object: {name}"+ gameObject.name);
            return;
        }
        
        var bullet = _bulletsSpawner.GetBullet();
        var position = _rigidbody.position;
        position.x += _xOffset;
        bullet.transform.position = position;
        bullet.transform.rotation = transform.rotation;
        bullet.Activate(_speed, _damage);
    }
}