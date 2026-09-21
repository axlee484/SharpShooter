using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float countDown = 1f;
    public float CountDown => countDown;
    public float SetCountDown(float value) => countDown = value;

    [SerializeField] private bool isRunning = false;
    public bool IsRunning => isRunning;

    public event Action TimerFinishedEvent;

    public void StartTimer()
    {
        if (isRunning) return;

        enabled = true;
        isRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    public void ResetTimer()
    {
        StopTimer(triggerEvent: false);
    }

    // Pass bool to control if the event should fire on stop
    public void StopTimer(bool triggerEvent = false)
    {
        StopAllCoroutines();
        isRunning = false;
        enabled = false;

        if (triggerEvent)
        {
            TimerFinishedEvent?.Invoke();
        }
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(countDown);
        StopTimer(triggerEvent: true);
    }
}