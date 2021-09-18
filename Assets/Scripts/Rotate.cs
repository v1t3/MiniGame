using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed;

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
