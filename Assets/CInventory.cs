using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventory : MonoBehaviour
{
    public List<Item> _inventory = new List<Item>();
    private Dictionary<int, int> _itemQuantity = new Dictionary<int, int>();

    public InventoryUI UI;

    public void AddItem(Item item, int quantity = 1)
    {
        if (quantity < 1)
            quantity = 1;

        for(int i = 0; i < quantity; i++)
            _inventory.Add(item);

        if(_itemQuantity.TryGetValue(item.id, out _))
        {
            _itemQuantity[item.id] += quantity;
        } else
        {
            _itemQuantity[item.id] = quantity;
        }

        if(UI != null)
        {
            UI.AddItem(item);
        }
    }
}
