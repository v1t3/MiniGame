using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace DistanceManagement
{
    public class ActivateByDistance : MonoBehaviour
    {
        [SerializeField] private float distanceToActivate = 20f;

        private Activator _activator;
        
        private bool _isActive = true;

        private void Start()
        {
            _activator = FindObjectOfType<Activator>();
        }

        public void CheckDistance(Vector3 playerPosition)
        {
            var distance = Vector3.Distance(transform.position, playerPosition);

            if (_isActive)
            {
                if (distance > distanceToActivate + 2f)
                {
                    Deactivate();
                }
            }
            else
            {
                if (distance < distanceToActivate)
                {
                    Activate();
                }
            }
        }

        private void Activate()
        {
            _isActive = true;
            gameObject.SetActive(true);
        }

        private void Deactivate()
        {
            _isActive = false;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _activator.objectsToActivate.Remove(this);
        }

        private void OnDrawGizmosSelected()
        {
            #if UNITY_EDITOR
            Handles.color = Color.grey;
            Handles.DrawWireDisc(transform.position, Vector3.forward, distanceToActivate);
            #endif
        }
    }
}