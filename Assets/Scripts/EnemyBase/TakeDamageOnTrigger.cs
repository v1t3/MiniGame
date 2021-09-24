using System;
using PlayerBase;
using UnityEngine;

namespace EnemyBase
{
    public class TakeDamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;

        [SerializeField] private bool dieOnAnyTrigger;
        
        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            //Fix double trigger
            if (_timer > 0.1f)
            {
                if (
                    other.attachedRigidbody &&
                    other.attachedRigidbody.GetComponent<Bullet>())
                {
                    _timer = 0;
                    enemyHealth.TakeDamage(1);
                }

                if (dieOnAnyTrigger && !other.isTrigger)
                {
                    enemyHealth.TakeDamage(10000);
                }
            }
        }
    }
}