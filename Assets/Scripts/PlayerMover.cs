using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _tapForce;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    
    private CustomPlayerInput _input;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new CustomPlayerInput();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _input.Player.Jump.performed -= OnJump;
        _input.Disable();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocityX = _horizontalSpeed;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            _minRotation,
            _rotationSpeed * Time.fixedDeltaTime);
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Impulse);
        
        transform.rotation = _maxRotation;
    }
}