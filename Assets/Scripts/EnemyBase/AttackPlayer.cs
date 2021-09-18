using PlayerBase;
using UnityEditor.UIElements;
using UnityEngine;

namespace EnemyBase
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField] private Transform spawn;
        private Transform player;

        [SerializeField] private GameObject objectPrefab;
    
        [SerializeField] private float flySpeed = 1;

        private void Start()
        {
            player = FindObjectOfType<PlayerMove>().transform;
        }

        private void ThrowObjectToPlayer()
        {
            Vector3 toTarget = (player.position - transform.position).normalized;
            GameObject newBullet = Instantiate(objectPrefab, spawn.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = toTarget * flySpeed;
            Destroy(newBullet, 10);
        }
    }
}
