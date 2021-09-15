using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int maxHealth = 8;
    [SerializeField] private AudioSource takeDamageSound;
    [SerializeField] private AudioSource addHealthSound;

    private bool _invulnerable;

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable) return;
        
        health -= damageValue;

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        takeDamageSound.Play();
            
        _invulnerable = true;
        Invoke(nameof(StopInvulnerable), 1f);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        addHealthSound.Play();
    }

    private void Die()
    {
        Debug.Log("Die");
    }
}