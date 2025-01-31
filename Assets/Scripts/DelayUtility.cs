using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayUtility : MonoBehaviour
{
    /// <summary>
    /// Executes an action after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds.</param>
    /// <param name="action">The action to execute after the delay.</param>
    public float delay;

    public void SetDelayTime(float time)
    {
        delay = time;
    }
    public void ExecuteAfterDelay(UnityEvent action)
    {
        StartCoroutine(DelayedAction(action));
    }

    private IEnumerator DelayedAction(UnityEvent action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
