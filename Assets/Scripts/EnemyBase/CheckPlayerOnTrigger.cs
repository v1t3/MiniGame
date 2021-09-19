using System;
using PlayerBase;
using UnityEngine;
using UnityEngine.Events;

namespace EnemyBase
{
    public class CheckPlayerOnTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent onPlayerVisible;
        [SerializeField] private UnityEvent onPlayerInvisible;
        
        private void OnTriggerEnter(Collider other)
        {
            if (
                other.attachedRigidbody &&
                other.attachedRigidbody.GetComponent<PlayerMove>()
            )
            {
                onPlayerVisible.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (
                other.attachedRigidbody &&
                other.attachedRigidbody.GetComponent<PlayerMove>()
            )
            {
                onPlayerInvisible.Invoke();
            }
        }
    }
}