using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public int _maxHealth = 100;
    [SerializeField] public int _currentHealth = 100;
    [SerializeField] bool _isEnemy = true;
    [SerializeField] HealthBar _healthBar;
    public bool _playerDied = false;
    public bool _enemyDied = false;
    void Start()
    {
        _currentHealth = _maxHealth;
        if (_healthBar != null)
        {
            _healthBar.SetMaxHealth(_maxHealth);
        }
    }

    void Update()
    {
        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (!_isEnemy)
        {
            _playerDied = true;
        }
        else
        {
            _enemyDied = true;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_healthBar != null)
        {
            _healthBar.SetHealth(_currentHealth);
        }
    }
}
