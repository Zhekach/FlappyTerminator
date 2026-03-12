using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Activate(float speed)
    {
        _speed = speed;
        _rigidbody.linearVelocity = (Vector2)transform.right * _speed;
    }

    public void ResetState()
    {
        _speed = 0f;
        _rigidbody.linearVelocity = Vector2.zero;
    }
}