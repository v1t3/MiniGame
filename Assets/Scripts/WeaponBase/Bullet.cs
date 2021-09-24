using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    
    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter(Collision other)
    {
        Die();
    }

    public void Die()
    {
        Destroy(Instantiate(effectPrefab, transform.position, Quaternion.identity), 2);
        Destroy(gameObject);
    }
}
