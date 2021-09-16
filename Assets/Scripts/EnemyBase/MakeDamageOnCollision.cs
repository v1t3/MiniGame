using PlayerBase;
using UnityEngine;

namespace EnemyBase
{
    public class MakeDamageOnCollision : MonoBehaviour
    {
        [SerializeField] private int damageValue = 1;
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody && other.rigidbody.GetComponent<PlayerHealth>())
            {
                other.rigidbody.GetComponent<PlayerHealth>().TakeDamage(damageValue);
            }
        }
    }
}
