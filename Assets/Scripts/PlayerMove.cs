using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Transform bodyTransform;

    [SerializeField] private float moveForce = 1f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float friction;
    [SerializeField] private float forceMultiplierGrounded = 1f;
    [SerializeField] private float forceMultiplierJump = 0.5f;

    [SerializeField] private Transform colliderTransform;
    [SerializeField] private float squatRate = 10f;

    [SerializeField] private Transform aimTransform;
    [SerializeField] private float rotateSpeed = 1;
    [SerializeField] private float rotateRate = 60;
    private float _smoothY = 0;

    [SerializeField] private bool _grounded;

    private void Update()
    {
        LookOnCursor();

        if (_grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        Vector3 targetScale = new Vector3(1, 1, 1);

        if (!_grounded || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S))
        {
            targetScale = new Vector3(1, 0.5f, 1);
        }
        

        colliderTransform.localScale = Vector3.Lerp(
            colliderTransform.localScale,
            targetScale,
            Time.deltaTime * squatRate
        );
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LookOnCursor()
    {
        Vector3 lookAt = transform.position - aimTransform.position;
        float targetY = rotateRate;

        if (lookAt.x < 0)
        {
            targetY = -rotateRate;
        }

        _smoothY = Mathf.Lerp(_smoothY, targetY, Time.deltaTime * rotateSpeed);
        bodyTransform.localEulerAngles = new Vector3(0, _smoothY, 0);
    }

    private void OnCollisionStay(Collision other)
    {
        foreach (var contactPoint in other.contacts)
        {
            float angle = Vector3.Angle(contactPoint.normal, Vector3.up);

            if (Mathf.Abs(angle) < 45)
            {
                _grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _grounded = false;
    }

    private void Move()
    {
        float speedMultiplier = forceMultiplierGrounded;

        if (!_grounded)
        {
            speedMultiplier = forceMultiplierJump;
        } else {
            //Friction
            playerRb.AddForce(-playerRb.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
        }
            
        if (
            (Input.GetAxis("Horizontal") > 0 && playerRb.velocity.x > maxSpeed) ||
            (Input.GetAxis("Horizontal") < 0 && playerRb.velocity.x < -maxSpeed)
        )
        {
            speedMultiplier = 0;
        }

        //Moving
        playerRb.AddForce(
            Input.GetAxis("Horizontal") * moveForce * speedMultiplier,
            0,
            0,
            ForceMode.VelocityChange
        );
    }

    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}