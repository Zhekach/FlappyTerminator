using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isActive;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isActive)
            _rigidbody.linearVelocityX = _speed;

    }

    public void Activate(float speed)
    {
        _speed = speed;
        _isActive = true;
    }

    public void ResetState()
    {
        _isActive = false;
        _speed = 0f;
    }
}