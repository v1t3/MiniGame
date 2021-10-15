using System;
using UnityEngine;

namespace WeaponBase
{
    public class Cargo : MonoBehaviour
    {
        [SerializeField] private RopeRenderer ropeRenderer;
        [SerializeField] private ConfigurableJoint joint;
        [SerializeField] private Transform ropeStart;

        [SerializeField] private float ropeLength = 1;

        private void Start()
        {
            ropeRenderer.gameObject.SetActive(true);
        }

        private void Update()
        {
            if (joint.connectedBody)
            {
                ropeRenderer.Draw(ropeStart.position, joint.connectedBody.position, ropeLength);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}