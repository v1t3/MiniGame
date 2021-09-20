using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PlayerBase;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float attackPeriod = 5;
    [SerializeField] private float attackRadius = 10;

    private float _timer;
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > attackPeriod)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, attackRadius);

            if (colliders.Any(colliderItem =>
                colliderItem.attachedRigidbody && colliderItem.attachedRigidbody.GetComponent<PlayerMove>()))
            {
                _timer = 0;
                animator.SetTrigger(Attack);
            }
        }
    }
}