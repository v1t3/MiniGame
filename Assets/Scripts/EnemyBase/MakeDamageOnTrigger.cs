using System;
using PlayerBase;
using UnityEngine;

namespace EnemyBase
{
    public class MakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damageValue = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(damageValue);
            }
        }
    }
}