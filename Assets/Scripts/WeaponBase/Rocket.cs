using System;
using System.Collections;
using System.Collections.Generic;
using PlayerBase;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // private Rigidbody _rigidbody;
    private Transform _playerTransform;
    
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float rotateSpeed = 1;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        // _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        Vector3 toPlayer = _playerTransform.position - transform.position;
        
        // _rigidbody.AddForce(transform.forward * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(toPlayer, Vector3.forward),
            Time.deltaTime * rotateSpeed
        );
    }
}