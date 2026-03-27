using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private float _xOffset;

    private Rigidbody2D _rigidbody;
    
    private float _speed;
    private int _damage;
    private Pool<Bullet> _pool;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Pool<Bullet> bulletsPool, float bulletSpeed, int damage)
    {
        _pool = bulletsPool;
        _speed = bulletSpeed;
        _damage = damage;
    }

    public void Shoot()
    {
        if(_pool == null)
            return;
        
        var bullet = _pool.Get();
        var position = _rigidbody.position;
        position.x += _xOffset;
        bullet.transform.position = position;
        bullet.transform.rotation = transform.rotation;
        bullet.Activate(_speed, _damage);
    }
}