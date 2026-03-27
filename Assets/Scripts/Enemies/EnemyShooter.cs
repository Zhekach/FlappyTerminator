using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Weapon))]
public class EnemyShooter : MonoBehaviour, IKillSource
{
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 1;
    [SerializeField] private Weapon _weapon;

    private bool _isActive;
    private Coroutine _shootRoutine;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }
    
    private void OnDisable()
    {
        Deactivate();
    }

    public void Initialize(Pool<Bullet> bulletsPool)
    {
        _weapon.Initialize(bulletsPool, _speed, _damage, this);
    }

    public void Activate()
    {
        if (_isActive)
            return;

        _isActive = true;
        
        _shootRoutine = StartCoroutine(ShootRoutine());
    }

    public void Deactivate()
    {
        if (!_isActive)
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
}
