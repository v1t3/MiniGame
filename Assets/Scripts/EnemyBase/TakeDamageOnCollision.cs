using UnityEngine;

namespace EnemyBase
{
    public class TakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;

        [SerializeField] private bool dieOnAnyCollision;

        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody)
            {
                var bullet = other.rigidbody.GetComponent<Bullet>();

                if (null != bullet)
                {
                    enemyHealth.TakeDamage(1);
                    bullet.Die();
                }
            }

            if (dieOnAnyCollision)
            {
                enemyHealth.TakeDamage(10000);
            }
        }
    }
}
