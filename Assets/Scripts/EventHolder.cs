using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventHolder : MonoBehaviour
{
    [SerializeField] private UnityEvent[] events;

    private void StartEvents(int index)
    {
        if (null != events[index])
        {
            events[index].Invoke();
        }
    }
}
