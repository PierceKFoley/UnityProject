using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public ItemSO Item;
    public int quantity = 1;

    private bool canInteract = true;

    public void Interact(CInteractor interactor)
    {
        if (!canInteract)
            return;

        if(interactor.transform.TryGetComponent<CInventory>(out CInventory inventory))
        {
            print("got inventory");
            canInteract = false;
            inventory.AddItem(Item.Item, quantity);
            Destroy(gameObject);
        }
    }
}
