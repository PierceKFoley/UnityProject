using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInteractor : MonoBehaviour
{
    public Camera cam;
    public float interactionRange = 5f;

    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.red, 3f, true);
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, interactionRange) && hitInfo.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(this);
            }
        }
    }
}
