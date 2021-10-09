using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Transform objectTransform;
    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightEuler;
    private Vector3 _targetEuler;

    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        objectTransform.localRotation = Quaternion.Lerp(
            objectTransform.localRotation,
            Quaternion.Euler(_targetEuler),
            Time.deltaTime * rotationSpeed
        );
    }

    public void RotateLeft()
    {
        _targetEuler = leftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = rightEuler;
    }
}