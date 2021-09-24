using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class Bear : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        [SerializeField] private float attackPeriod = 5;
        
        private bool _isPlayerVisible;

        private float _timer;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Damage = Animator.StringToHash("Damage");

        private void Start()
        {
            _timer = attackPeriod;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > attackPeriod && _isPlayerVisible)
            {
                _timer = 0;
                animator.SetTrigger(Attack);
            }
        }

        /**
         * Using in Events
         */
        public void SetPlayerVisible(bool value)
        {
            _isPlayerVisible = value;
        }

        public void TriggerDamage()
        {
            animator.SetTrigger(Damage);
        }
    }
}
