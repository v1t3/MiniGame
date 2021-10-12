using UnityEngine;
using UnityEngine.Events;

namespace WeaponBase
{
    public class MassBullet : MonoBehaviour
    {
        [SerializeField] private GameObject cargoPrefab;

        [SerializeField] private UnityEvent onDie;

        private bool _isCargoCreated;

        private void Start()
        {
            Destroy(gameObject, 10);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody && !_isCargoCreated)
            {
                _isCargoCreated = true;
                var newCargo = Instantiate(cargoPrefab, other.rigidbody.position, Quaternion.identity);
                newCargo.GetComponent<HingeJoint>().connectedBody = other.rigidbody;
            }
            
            Die(0.1f);
        }

        public void Die(float delay = 0)
        {
            onDie.Invoke();
            Destroy(gameObject, delay);
        }
    }
}