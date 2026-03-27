using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Weapon))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 1;
    [SerializeField] private Weapon _weapon;

    private Coroutine _shootRoutine;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
    }

    public void Initialize(Pool<Bullet> bulletsPool)
    {
        _weapon.Initialize(bulletsPool, _speed, _damage);
    }

    private void OnEnable()
    {
        _shootRoutine = StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }
    }

    private IEnumerator ShootRoutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _weapon.Shoot();

            yield return wait;
        }
    }
}
