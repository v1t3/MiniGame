using UI;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerBase
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int health = 5;
        [SerializeField] private int maxHealth = 8;

        [SerializeField] private Health healthUI;
    
        private bool _invulnerable;

        [SerializeField] private UnityEvent eventOnTakeDamage;
        [SerializeField] private UnityEvent eventOnAddHealth;
        [SerializeField] private UnityEvent eventOnDie;

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
            
            eventOnTakeDamage.Invoke();

            healthUI.DisplayHealth(health);
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
        
            healthUI.DisplayHealth(health);
            eventOnAddHealth.Invoke();
        }

        private void Die()
        {
            Debug.Log("Die");
            eventOnDie.Invoke();
        }
    }
}