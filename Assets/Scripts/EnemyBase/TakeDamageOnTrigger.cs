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
            if (other.attachedRigidbody)
            {
                var bullet = other.attachedRigidbody.GetComponent<Bullet>();

                if (null != bullet)
                {
                    enemyHealth.TakeDamage(1);
                    bullet.Die();
                }
            }

            if (dieOnAnyTrigger && !other.isTrigger)
            {
                enemyHealth.TakeDamage(10000);
            }
        }
    }
}