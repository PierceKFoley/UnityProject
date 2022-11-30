using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter = new UnityEvent();
    public bool triggerMultiple = false;

    bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!triggerMultiple && triggered)
            return;

        if(other.tag == "Player")
        {
            triggered = true;
            onTriggerEnter?.Invoke();
        }
    }
}
