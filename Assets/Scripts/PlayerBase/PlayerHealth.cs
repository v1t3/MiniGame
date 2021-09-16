using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private int maxHealth = 8;
    [SerializeField] private AudioSource takeDamageSound;
    [SerializeField] private AudioSource addHealthSound;

    [SerializeField] private HealthUI healthUI;
    
    [SerializeField] private DamageScreen damageScreen;
    
    private bool _invulnerable;

    private void Start()
    {
        healthUI.Setup(maxHealth);
        healthUI.DisplayHealth(health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable) return;
        
        health -= damageValue;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
            
        _invulnerable = true;
        Invoke(nameof(StopInvulnerable), 1f);

        takeDamageSound.Play();
        healthUI.DisplayHealth(health);
        damageScreen.StartEffect();
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
        healthUI.DisplayHealth(health);
    }

    private void Die()
    {
        Debug.Log("Die");
    }
}