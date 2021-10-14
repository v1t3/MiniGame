using UnityEngine;

namespace WeaponBase
{
    public class Hook : MonoBehaviour
    {
        private FixedJoint _fixedJoint;

        public Rigidbody selfRigidbody;

        [SerializeField] private Collider selfCollider;
        [SerializeField] private Collider playerCollider;
        [SerializeField] private RopeGun ropeGun;

        private void Start()
        {
            Physics.IgnoreCollision(selfCollider, playerCollider);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!_fixedJoint)
            {
                _fixedJoint = gameObject.AddComponent<FixedJoint>();
                
                if (other.rigidbody)
                {
                    _fixedJoint.connectedBody = other.rigidbody;
                }
                
                ropeGun.CreateSpring();
            }
        }

        public void StopFix()
        {
            if (_fixedJoint)
            {
                Destroy(_fixedJoint);
            }
        }
    }
}