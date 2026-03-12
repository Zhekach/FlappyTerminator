using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputProvider))]
[RequireComponent(typeof(Weapon))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 3f;

    private Weapon _weapon;
    
    private PlayerInputProvider _inputProvider;
    private CustomPlayerInput _input;
    
    public float BulletSpeed => _bulletSpeed;

    private void Awake()
    {
        _inputProvider = GetComponent<PlayerInputProvider>();
        _input = _inputProvider.GetPlayerInput();
    }

    private void OnEnable()
    {
        _input.Player.Fire.performed += OnShoot;
    }

    private void OnDisable()
    {
        _input.Player.Fire.performed -= OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }
}
