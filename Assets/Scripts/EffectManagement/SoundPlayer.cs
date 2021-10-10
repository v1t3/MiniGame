using UnityEngine;

namespace EffectManagement
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void PlaySound()
        {
            audioSource.Play();
        }
    }
}
