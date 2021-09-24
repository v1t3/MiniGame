using System;
using UnityEngine;

public class AnimationTriggerUpdater : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string triggerName;
    
    [SerializeField] private float period;
    [SerializeField] private bool isContinuous;
    private float _timer;

    private void Start()
    {
        _timer = period;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (isContinuous)
        {
            StartTrigger();
        }
    }

    public void StartTrigger()
    {
        if (_timer > period)
        {
            _timer = 0;
            animator.SetTrigger(triggerName);
        }
    }
}