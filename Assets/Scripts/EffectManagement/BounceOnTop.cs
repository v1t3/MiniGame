using UnityEngine;

namespace EffectManagement
{
    public class BounceOnTop : MonoBehaviour
    {
        public float bounciness = 1;

        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody && other.rigidbody.transform.position.y > transform.position.y)
            {
                other.rigidbody.AddForce(Vector3.up * bounciness, ForceMode.VelocityChange);
            }
        }
    }
}
