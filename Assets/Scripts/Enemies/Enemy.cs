using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour, IKillSource
{
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private Health _health;
    
    public Health  Health => _health; 

    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
        _health = GetComponent<Health>();
    }
}