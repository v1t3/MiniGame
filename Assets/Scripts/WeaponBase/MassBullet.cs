using UnityEngine;
using UnityEngine.Events;

namespace WeaponBase
{
    public class MassBullet : MonoBehaviour
    {
        [SerializeField] private GameObject cargoPrefab;

        [SerializeField] private UnityEvent onDie;

        private ConfigurableJoint _joint;

        private void Start()
        {
            Destroy(gameObject, 10);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody && !_joint)
            {
                var newCargo = Instantiate(cargoPrefab, other.rigidbody.position, Quaternion.identity);
                _joint = newCargo.GetComponent<ConfigurableJoint>();
                _joint.connectedBody = other.rigidbody;
                
                //Привяжем груз к месту касания
                var localPoint = other.rigidbody.transform.InverseTransformPoint(other.contacts[0].point);
                _joint.connectedAnchor = localPoint;
            }
            
            Die();
        }

        public void Die(float delay = 0)
        {
            onDie.Invoke();
            Destroy(gameObject, delay);
        }
    }
}