using System;
using PlayerBase;
using UnityEngine;

namespace EnemyBase
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;

        [SerializeField] private bool dieOnAnyTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody &&
                other.attachedRigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }

            if (dieOnAnyTrigger && !other.isTrigger)
            {
                enemyHealth.TakeDamage(10000);
            }
        }
    }
}