using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
        for (float t = 1; t > 0; t -= Time.deltaTime * fadeSpeed)
        {
            damageImage.color = new Color(1, 0, 0, t);
            yield return null;
        }

        damageImage.enabled = false;
    }
}