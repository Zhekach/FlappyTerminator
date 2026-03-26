using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    
    private IKillSource _owner;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Activate(float speed, int damage,  IKillSource owner)
    {
        _speed = speed;
        _damage = damage;
        _owner = owner;
        _rigidbody.linearVelocity = (Vector2)transform.right * _speed;
    }

    public void ResetState()
    {
        _speed = 0f;
        _rigidbody.linearVelocity = Vector2.zero;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>( out IDamageable target))
            OnHit(target);    
    }

    private void OnHit(IDamageable target)
    {
        target.TakeDamage(_damage, _owner);
    }
}