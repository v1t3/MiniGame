using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DistanceManagement
{
    public class Activator : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        public List<ActivateByDistance> objectsToActivate;
        
        private void Update()
        {
            for (int i = 0; i < objectsToActivate.Count; i++)
            {
                if (null != objectsToActivate[i])
                {
                    objectsToActivate[i].CheckDistance(playerTransform.position);
                }
            }
        }

        /**
         * Заполнить список по кнопке
         */
        [ContextMenu("FindAllObjects")]
        public void FindAllObjects()
        {
            objectsToActivate = FindObjectsOfType<ActivateByDistance>().ToList();
        }
    }
}
