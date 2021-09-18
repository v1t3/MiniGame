using System;
using System.Collections;
using System.Collections.Generic;
using PlayerBase;
using UnityEditor.UIElements;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private Transform _playerTransform;
    
    [SerializeField] private float speed = 3;
    [SerializeField] private float timeToReachSpeed = 5;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = rb.mass * (toPlayer * speed - rb.velocity) / timeToReachSpeed;
        
        rb.AddForce(force);
    }
}
