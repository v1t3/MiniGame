using PlayerBase;
using UnityEngine;

namespace Loot
{
    public class LootHeal : MonoBehaviour
    {
        [SerializeField] private int healthValue = 1;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(healthValue);
                Destroy(gameObject);
            }
        }
    }
}
