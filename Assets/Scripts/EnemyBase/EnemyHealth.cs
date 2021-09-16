using UnityEngine;

namespace EnemyBase
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int health;

        public void TakeDamage(int damageValue)
        {
            health -= damageValue;

            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
