using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractable
{
    Animator animator;
    public UnityEvent onPressed = new UnityEvent();

    public bool canInteract = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact(CInteractor interactor)
    {
        if (canInteract)
        {
            animator?.SetTrigger("Pressed");
            onPressed?.Invoke();
        }
    }
}
