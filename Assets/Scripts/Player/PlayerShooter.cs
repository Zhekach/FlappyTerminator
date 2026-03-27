using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputProvider))]
[RequireComponent(typeof(Weapon))]
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 3f;
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField] private float _delayBetweenShoots = 1f;

    private Weapon _weapon;
    private PlayerInputProvider _inputProvider;
    private CustomPlayerInput _input;
    
    private Coroutine _reloadingCoroutine;
    private WaitForSeconds _reloadingDelay;
    private bool _isReloading;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        _inputProvider = GetComponent<PlayerInputProvider>();
        _input = _inputProvider.GetPlayerInput();
        _reloadingDelay = new WaitForSeconds(_delayBetweenShoots);
    }

    private void OnEnable()
    {
        _input.Player.Fire.performed += OnShoot;
    }

    private void OnDisable()
    {
        _input.Player.Fire.performed -= OnShoot;
    }

    public void Initialize(BulletsSpawner bulletsSpawner)
    {
        _weapon.Initialize(bulletsSpawner, _bulletSpeed, _bulletDamage);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (_isReloading == false)
        {
            _weapon.Shoot();
            _reloadingCoroutine = StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        _isReloading = true;
        yield return _reloadingDelay;
        
        _isReloading = false;
        _reloadingCoroutine = null;
    }
}
