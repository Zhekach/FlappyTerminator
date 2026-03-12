using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Weapon : MonoBehaviour
{
    private float _bulletsSpeed;
    private BulletsPool _bulletsPool;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody  = GetComponent<Rigidbody2D>();
    }

    public void Initialize(BulletsPool bulletsPool, float bulletSpeed)
    {
        _bulletsPool = bulletsPool;
        _bulletsSpeed = bulletSpeed;
    }

    public void Shoot()
    {
        var bullet = _bulletsPool.Get();
    }
}
