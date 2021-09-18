using UnityEngine;
using UnityEngine.Events;

namespace EnemyBase
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health = 1;
        [SerializeField] private UnityEvent eventOnTakeDamage;
        [SerializeField] private UnityEvent eventOnDie;

        public void TakeDamage(int damageValue)
        {
            health -= damageValue;
            
            eventOnTakeDamage.Invoke();

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            eventOnDie.Invoke();
            Destroy(gameObject);
        }
    }
}
