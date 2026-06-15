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

    private void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().GetDamage());
            Destroy(collision.gameObject);
        }
    }
}
