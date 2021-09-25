using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using PlayerBase;
using UnityEngine;
using WeaponBase;

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

    /**
     * todo Заменить на addForce
     */
    private void Update()
    {
        // По неизвестным причинам, ракета отклоняется по z
        transform.position += new Vector3(transform.forward.x, transform.forward.y, 0) * moveSpeed * Time.deltaTime;

        Vector3 toPlayer = _playerTransform.position - transform.position;
        toPlayer.z = 0;

        // _rigidbody.AddForce(transform.forward * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(toPlayer, Vector3.forward),
            Time.deltaTime * rotateSpeed
        );
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<Bear>())
        {
            GetComponent<Bullet>().enabled = true;
        }
    }
}