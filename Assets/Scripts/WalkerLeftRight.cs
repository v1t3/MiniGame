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
    
    [SerializeField] private Transform leftTarget;
    [SerializeField] private Transform rightTarget;

    [SerializeField] private float speed;

    [SerializeField] private float stopTime;
    
    [SerializeField] private Transform rayStart;

    [SerializeField] private Direction currentDirection = Direction.Left;

    [SerializeField] private UnityEvent onLeftTarget;
    [SerializeField] private UnityEvent onRightTarget;

    private bool _isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped)
        {
            return;
        }
        
        var position = new Vector3(Time.deltaTime * speed, 0, 0);
        
        if (currentDirection == Direction.Left)
        {
            transform.position -= position;

            if (transform.position.x < leftTarget.position.x)
            {
                currentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                onLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += position;

            if (transform.position.x > rightTarget.position.x)
            {
                currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), stopTime);
                onRightTarget.Invoke();
            }
        }

        if (rayStart)
        {
            AttachDown();
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }

    private void AttachDown()
    {
        if (rayStart && Physics.Raycast(rayStart.position, Vector3.down, out RaycastHit hit))
        {
            transform.position = hit.point;
        }
    }
}