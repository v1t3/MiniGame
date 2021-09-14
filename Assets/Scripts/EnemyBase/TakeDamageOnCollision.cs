using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody && other.rigidbody.GetComponent<Bullet>())
        {
            enemyHealth.TakeDamage(1);
        }
    }
}
