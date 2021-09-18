using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject bulletPrefab;
    
    [SerializeField] private float flySpeed = 1;

    private void ThrowObject()
    {
        Vector3 toTarget = (target.position - transform.position).normalized;
        GameObject newBullet = Instantiate(bulletPrefab, spawn.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = toTarget * flySpeed;
    }
}
