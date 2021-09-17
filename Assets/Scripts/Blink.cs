using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

    [SerializeField] private float blinkTime = 1;
    [SerializeField] private float blinkSpeed = 10;
    
    [SerializeField] private Renderer[] rendererList;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    //todo Переделать
    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < blinkTime; t += Time.deltaTime)
        {
            var color = Mathf.Sin(t * blinkSpeed) * 0.5f + 0.5f;

            foreach (var rendererItem in rendererList)
            {
                rendererItem.material.SetColor(EmissionColor, new Color(0.003f, 0, color, 1));
            }

            yield return null;
        }
    }
}