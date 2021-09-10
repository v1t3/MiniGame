using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float friction;

    [SerializeField] private Transform colliderTransform;
    [SerializeField] private float squatRate = 10f;

    [SerializeField] private Transform aimTransform;
    [SerializeField] private float rotateSpeed = 1;
    [SerializeField] private float rotateRate = 60;

    private bool _grounded;

    private void Update()
    {
        Jump();
        Squat();
        LookOnCursor();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LookOnCursor()
    {
        Vector3 lookAt = transform.position - aimTransform.position;
        lookAt.y = 0;
        
        //todo Вопрос: как ограничение поворота можно сделать проще?
        Quaternion lookAtQ = Quaternion.LookRotation(lookAt);
        lookAtQ.ToAngleAxis(out var angle, out var axis); //Не до конца понимаю, как работает этот метод
        lookAtQ.eulerAngles = new Vector3(
            lookAtQ.eulerAngles.x,
            Mathf.Clamp(angle, -rotateRate, rotateRate) * axis.y,
            lookAtQ.eulerAngles.z
        );

        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            lookAtQ,
            Time.deltaTime * rotateSpeed
        );
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
        float speedMultiplier = 1f;

        if (!_grounded)
        {
            speedMultiplier = 0.1f;
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
            Input.GetAxis("Horizontal") * moveSpeed * speedMultiplier * Time.deltaTime,
            0,
            0,
            ForceMode.VelocityChange
        );

        //Friction
        playerRb.AddForce(-playerRb.velocity.x * friction * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        if (_grounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void Squat()
    {
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
}