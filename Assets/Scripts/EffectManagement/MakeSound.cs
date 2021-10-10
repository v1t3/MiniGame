using UnityEngine;

namespace EffectManagement
{
    public class MakeSound : MonoBehaviour
    {
        [SerializeField] private GameObject soundPrefab;

        /**
     * Using in event
     */
        public void CreateAndPlay()
        {
            GameObject newSound = Instantiate(soundPrefab, transform.position, Quaternion.identity);
            AudioSource source = newSound.GetComponent<AudioSource>();
        
            Destroy(newSound, source.clip.length);
        
            source.Play();
        }
    
        /**
     * Using in event
     */
        public void CreateNewSound()
        {
            GameObject newSound = Instantiate(soundPrefab, transform.position, Quaternion.identity);
            AudioSource source = newSound.GetComponent<AudioSource>();
        
            Destroy(newSound, source.clip.length);
        }
    }
}