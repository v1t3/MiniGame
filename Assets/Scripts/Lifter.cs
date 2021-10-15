using UnityEngine;

public class Lifter : MonoBehaviour
{
    [SerializeField] private float getUpSpeed = 10;

    public void GetUp()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.identity,
            Time.deltaTime * getUpSpeed
        );
    }
}