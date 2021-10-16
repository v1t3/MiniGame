using PlayerBase;
using UnityEngine;

namespace Weapons
{
    public class Rocket : MonoBehaviour
    {
        private Transform _playerTransform;

        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private float rotateSpeed = 1;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMove>().transform;
        }

        /**
         * todo Заменить на addForce
         */
        private void Update()
        {
            // Исправление отклонения ракеты по z
            transform.position += new Vector3(transform.forward.x, transform.forward.y, 0) * moveSpeed * Time.deltaTime;

            Vector3 toPlayer = _playerTransform.position - transform.position;
            toPlayer.z = 0;

            // _rigidbody.AddForce(transform.forward * moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(toPlayer, Vector3.forward),
                Time.deltaTime * rotateSpeed
            );
        }
    }
}