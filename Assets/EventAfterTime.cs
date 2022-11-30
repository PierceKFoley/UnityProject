using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAfterTime : MonoBehaviour
{
    public UnityEvent Events = new UnityEvent();
    public float SecondsBeforeEvent = 1f;

    public void Invoke()
    {
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(SecondsBeforeEvent);
            break;
        }
        Events?.Invoke();
    }
}
