using PlayerBase;
using UnityEngine;
using UnityEngine.Events;

public class RotateToPlayer : MonoBehaviour
{

    [SerializeField] private UnityEvent onLeft;
    [SerializeField] private UnityEvent onRight;
    
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        if (transform.position.x > _playerTransform.position.x)
        {
            onLeft.Invoke();
        }
        else
        {
            onRight.Invoke();
        }
    }
}
