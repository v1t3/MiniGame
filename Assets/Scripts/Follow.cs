using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lerpRate;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpRate);
    }
}
