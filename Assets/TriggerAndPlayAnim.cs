using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndPlayAnim : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "";

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger(triggerName);
    }
}
