using UnityEngine;
using UnityEngine.Events;

namespace WeaponBase
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private UnityEvent onDie;

        private void Start()
        {
            Destroy(gameObject, 10);
        }

        private void OnCollisionEnter(Collision other)
        {
            Die();
        }

        public void Die()
        {
            onDie.Invoke();
            Destroy(gameObject);
        }
    }
}
