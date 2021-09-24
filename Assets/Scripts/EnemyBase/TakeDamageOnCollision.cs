using UnityEngine;

namespace EnemyBase
{
    public class TakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;

        [SerializeField] private bool dieOnAnyCollision;

        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody && other.rigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
                other.gameObject.SetActive(false);
            }

            if (dieOnAnyCollision)
            {
                enemyHealth.TakeDamage(10000);
            }
        }
    }
}
