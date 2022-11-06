using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] public int _maxHealth = 100;
    [SerializeField] public int _currentHealth = 100;

    void Start()
    {
        
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

    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
