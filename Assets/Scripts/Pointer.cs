using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    [SerializeField] private Transform aim;

    private void LateUpdate()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        plane.Raycast(ray, out float distance);
        aim.position = ray.GetPoint(distance);

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
