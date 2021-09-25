using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public Transform spawnTransform;
    
    public GameObject objectPrefab;

    public float destroyDelay = 10f;

    /**
     * Using in events
     */
    public void Create()
    {
        Destroy(Instantiate(objectPrefab, spawnTransform.position, spawnTransform.rotation), destroyDelay);
    }
}
