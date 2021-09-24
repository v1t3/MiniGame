using PlayerBase;
using UnityEngine;
using UnityEngine.Events;

namespace EnemyBase
{
    public class WatchOnPlayer : MonoBehaviour
    {
        private Transform _playerTransform;
    
        [SerializeField] private float boundaryDistance;

        [SerializeField] private UnityEvent onTargetVisible;
        [SerializeField] private UnityEvent onTargetInvisible;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMove>().transform;
        }

        private void FixedUpdate()
        {
            float distanceToObject = Vector3.Distance(transform.position, _playerTransform.position);

            if (distanceToObject <= boundaryDistance)
            {
                onTargetVisible.Invoke();
            }
            else
            {
                onTargetInvisible.Invoke();
            }
        }
    }
}
