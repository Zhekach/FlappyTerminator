using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    
    private int _currentHealth;
    
    public event Action Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        if(damage <0) 
            throw new ArgumentException("Damage must be greater than 0");
        
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
             Died?.Invoke();
        }
    }

    public void ResetState()
    {
        _currentHealth = _maxHealth;
    }
}
