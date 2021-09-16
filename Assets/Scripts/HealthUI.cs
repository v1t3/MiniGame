using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthIconPrefab;

    [HideInInspector] public List<GameObject> healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(healthIconPrefab, transform);
            newIcon.SetActive(false);
            healthIcons.Add(newIcon);
        }
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(i < health);
        }
    }
}