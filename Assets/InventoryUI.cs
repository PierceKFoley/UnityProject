using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject icon;
    public GameObject rootUI;
    public CCMovement characterController;
    public Item_UI itemUIPrefab;
    public Transform itemUIRoot;

    public bool isOpen = false;


    public void ToggleOpen()
    {
        isOpen = !isOpen;

        rootUI.SetActive(isOpen);
        icon.SetActive(!isOpen);
        characterController.enableCam = !isOpen;

        Cursor.lockState = isOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ToggleOpen();
    }

    public void AddItem(Item item)
    {
        Instantiate<Item_UI>(itemUIPrefab, itemUIRoot).Initialize(item);
    }
}
