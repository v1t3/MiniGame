using PlayerBase;
using UnityEngine;

namespace Enemy
{
    public class Hen : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private Transform _playerTransform;
    
        [SerializeField] private float speed = 3;
        [SerializeField] private float timeToReachSpeed = 5;

        private bool _isPlayerVisible;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMove>().transform;
        }

        private void FixedUpdate()
        {
            if (_isPlayerVisible && timeToReachSpeed > 0)
            {
                Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
                Vector3 force = rb.mass * (toPlayer * speed - rb.velocity) / timeToReachSpeed;

                rb.AddForce(force);
            }
        }

        public void SetPlayerVisible(bool value)
        {
            _isPlayerVisible = value;
        }
    }
}
