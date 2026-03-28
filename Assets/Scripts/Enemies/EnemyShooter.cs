using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Weapon))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private Weapon _weapon;

    private Coroutine _shootRoutine;
    private bool _isActive;
    private bool _isInitialized;

    private void Awake()
    {
        if (_weapon == null)
            _weapon = GetComponent<Weapon>();
    }
    
    public void Initialize(BulletsSpawner bulletsSpawner)
    {
        _weapon.Initialize(bulletsSpawner, _speed, _damage);
        _isInitialized = true;
    }
    
    public void Activate()
    {
        if (_isInitialized == false)
        {
            Debug.LogError($"EnemyShooter is not initialized: {name}", this);
            return;
        }

        if (_isActive)
            return;

        _isActive = true;
        _shootRoutine = StartCoroutine(ShootRoutine());
    }
    
    public void Deactivate()
    {
        if (_isActive == false)
            return;

        _isActive = false;

        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isActive)
        {
            _weapon.Shoot();
            yield return wait;
        }
    }

    private void OnDisable()
    {
        Deactivate();
    }
}