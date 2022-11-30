using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public ItemSO Item;
    public int quantity = 1;

    public UnityEvent onPickup = new UnityEvent();

    private bool canInteract = true;

    public void Interact(CInteractor interactor)
    {
        if (!canInteract)
            return;

        if(interactor.transform.TryGetComponent<CInventory>(out CInventory inventory))
        {
            canInteract = false;
            onPickup?.Invoke();
            inventory.AddItem(Item.Item, quantity);
            Destroy(gameObject);
        }
    }
}
