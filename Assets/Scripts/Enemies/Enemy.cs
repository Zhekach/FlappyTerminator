using UnityEngine;

[RequireComponent(typeof(EnemyShooter))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Weapon))]
public class Enemy : MonoBehaviour, IKillSource, IPoolable
{
    [SerializeField] private EnemyShooter _shooter;
    [SerializeField] private Health _health;
    
    public Health  Health => _health; 

    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
        _health = GetComponent<Health>();
    }

    public void OnSpawn()
    {
        Debug.Log("Enemy On Spawn");
    }

    public void OnDespawn()
    {
        Debug.Log("Enemy On Despawn");
    }
}