using UnityEngine;

public class MakeSound : MonoBehaviour
{
    [SerializeField] private GameObject soundPrefab;

    public void CreateAndPlay()
    {
        GameObject newSound = Instantiate(soundPrefab, transform.position, Quaternion.identity);
        AudioSource source = newSound.GetComponent<AudioSource>();
        
        Destroy(newSound, source.clip.length);
        
        source.Play();
    }
}