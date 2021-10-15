using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WalkerLeftRight : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right
    }

    [SerializeField] private Rigidbody selfRb;

    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;

    [SerializeField] private float speed;
    [SerializeField] private float stopTime;

    [SerializeField] private Direction currentDirection = Direction.Left;
    [SerializeField] private UnityEvent onLeftTarget;
    [SerializeField] private UnityEvent onRightTarget;

    private bool _isStopped;
    private Vector3 _currentTarget;

    private void Start()
    {
        selfRb = GetComponent<Rigidbody>();
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        if (_isStopped)
        {
            return;
        }

        if (currentDirection == Direction.Left)
        {
            _currentTarget = selfRb.transform.position - Vector3.right;

            if (selfRb.transform.position.x < leftTarget.position.x)
            {
                currentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                onLeftTarget.Invoke();
            }
        }
        else
        {
            _currentTarget = selfRb.transform.position + Vector3.right;

            if (selfRb.transform.position.x > rightTarget.position.x)
            {
                currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                onRightTarget.Invoke();
            }
        }

        if (!_isStopped)
        {
            selfRb.MovePosition(Vector3.Slerp(transform.position, _currentTarget, Time.deltaTime * speed));
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}