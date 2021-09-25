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
            Die(0.1f);
        }

        public void Die(float delay = 0)
        {
            onDie.Invoke();
            Destroy(gameObject, delay);
        }
    }
}
