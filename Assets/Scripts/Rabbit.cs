using System;
using System.Collections;
using System.Collections.Generic;
using PlayerBase;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float attackPeriod = 5;
    private float _timer;

    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Update()
    {
        _timer += Time.deltaTime;

        Vector3 fwd = -transform.right;
        Vector3 from = transform.position;
        from.y += transform.localScale.y / 2;

        Debug.DrawRay(from, fwd * 10, Color.green);

        Physics.Raycast(from, fwd, out var hit, 10);
        
        if (
            _timer > attackPeriod &&
            hit.rigidbody && 
            hit.rigidbody.GetComponent<PlayerMove>()
        )
        {
            _timer = 0;
            animator.SetTrigger(Attack);
        }
    }
}