using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DamageScreen : MonoBehaviour
    {
        [SerializeField] private Image damageImage;
    
        [SerializeField] private float fadeSpeed = 1;

        private Coroutine effectCoroutine;

        public void StartEffect()
        {
            if (null != effectCoroutine)
            {
                StopCoroutine(effectCoroutine);
            }

            effectCoroutine = StartCoroutine(ShowEffect());
        }

        private IEnumerator ShowEffect()
        {
            damageImage.enabled = true;
            var color = damageImage.color;
        
            for (float t = 1; t > 0; t -= Time.deltaTime * fadeSpeed)
            {
                color.a = t;
                damageImage.color = color;
            
                yield return null;
            }

            damageImage.enabled = false;
        }
    }
}