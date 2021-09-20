using PlayerBase;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightEuler;

    [SerializeField] private float rotationSpeed = 5;

    private Transform _playerTransform;
    private Vector3 _targetEuler;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        _targetEuler = (transform.position.x < _playerTransform.position.x) ? rightEuler : leftEuler;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * rotationSpeed);
    }
}
