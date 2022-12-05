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

    [SerializeField] GameObject _damagedPanel = null;

    void Start()
    {
        _currentHealth = _maxHealth;
        if (_healthBar != null)
        {
            _healthBar.SetMaxHealth(_maxHealth);
        }

        if (_damagedPanel != null)
        {
            _damagedPanel.SetActive(false);
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
        if (_currentHealth <= 0)
        {
            Kill();
        }
        if (_damagedPanel != null)
        {
            StartCoroutine(DamagePanel());
        }
    }

    IEnumerator DamagePanel()
    {
        _damagedPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _damagedPanel.SetActive(false);
    }

}
