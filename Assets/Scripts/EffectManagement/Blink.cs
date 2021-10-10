using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EffectManagement
{
    public class Blink : MonoBehaviour
    {
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        [SerializeField] private float blinkTime = 1;
        [SerializeField] private float blinkSpeed = 1;
    
        [SerializeField] private List<Renderer> rendererList = new List<Renderer>();
        private List<Color> _originalColors = new List<Color>(); 

        private void Start()
        {
            foreach (var rendererItem in rendererList)
            {
                foreach (var material in rendererItem.materials)
                {
                    _originalColors.Add(material.GetColor(EmissionColor));
                }
            }
        }

        public void StartBlink()
        {
            StartCoroutine(BlinkEffect());
        }

        private IEnumerator BlinkEffect()
        {
            for (float t = 0; t < blinkTime; t += Time.deltaTime)
            {
                var color = Mathf.Sin(t * blinkSpeed) * 0.5f + 0.5f;
    
                foreach (var rendererItem in rendererList)
                {
                    foreach (var material in rendererItem.materials)
                    {
                        material.SetColor(EmissionColor, new Color(0.003f, 0, color, 1));
                    }
                }
    
                yield return null;
            }
    
            //Восстановим оригинальные цвета
            var i = 0;
            foreach (var rendererItem in rendererList)
            {
                foreach (var material in rendererItem.materials)
                {
                    material.SetColor(EmissionColor, _originalColors[i]);
                    i++;
                }
            }
        }
    }
}