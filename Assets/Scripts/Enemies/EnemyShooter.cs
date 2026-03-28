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

    public void Initialize(BulletsSpawner bulletsSpawner)
    {
        _weapon.Initialize(bulletsSpawner, _speed, _damage);
    }

    private void OnDisable()
    {
        if (_shootRoutine != null)
        {
            StopCoroutine(_shootRoutine);
            _shootRoutine = null;
        }
    }
    
    public void Activate()
    {
        _shootRoutine = StartCoroutine(ShootRoutine());
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
