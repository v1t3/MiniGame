using UnityEngine;
using WeaponBase;

namespace Loot
{
    public class LootBullets : MonoBehaviour
    {
        [SerializeField] private int gunIndex;
        [SerializeField] private int bulletsCount;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerArmory>())
            {
                other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(gunIndex, bulletsCount);
                Destroy(gameObject);
            }
        }
    }
}
