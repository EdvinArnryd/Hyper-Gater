using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _maxHealth;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
            return;
        }
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
    }
}
