using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private float _xOffset;

    private Rigidbody2D _rigidbody;
    
    private float _speed;
    private int _damage;
    private Pool<Bullet> _pool;
    private IKillSource _owner;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Pool<Bullet> bulletsPool, float bulletSpeed, int damage, IKillSource owner)
    {
        _pool = bulletsPool;
        _speed = bulletSpeed;
        _damage = damage;
        _owner = owner;
    }

    public void Shoot()
    {
        var bullet = _pool.Get();
        var position = _rigidbody.position;
        position.x += _xOffset;
        bullet.transform.position = position;
        bullet.transform.rotation = transform.rotation;
        bullet.Activate(_speed, _damage, _owner);
    }
}