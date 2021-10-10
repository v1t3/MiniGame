using UnityEngine;
using Random = UnityEngine.Random;

namespace EffectManagement
{
    public class Throw : MonoBehaviour
    {
        [SerializeField] private GameObject objectPrefab;

        [SerializeField] private float force = 1;
        [SerializeField] private float maxRotationSpeed;

        [ContextMenu("Throw")]
        public void ThrowObject()
        {
            GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
            var rb = newObject.GetComponent<Rigidbody>();
        
            rb.AddForce(transform.forward * force, ForceMode.VelocityChange);

            if (maxRotationSpeed > 0)
            {
                rb.angularVelocity = new Vector3(
                    Random.Range(-maxRotationSpeed, maxRotationSpeed),
                    Random.Range(-maxRotationSpeed, maxRotationSpeed),
                    Random.Range(-maxRotationSpeed, maxRotationSpeed)
                );
            }
        }
    }
}