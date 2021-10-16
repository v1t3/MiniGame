using UnityEngine;
using UnityEngine.Events;

public class DestroyOnPosition : MonoBehaviour
{
    [SerializeField] private float minPositionY = -50f;
    [SerializeField] private UnityEvent onMinPositionY;

    private void Update()
    {
        if (transform.position.y < minPositionY)
        {
            onMinPositionY.Invoke();
        }
    }
}