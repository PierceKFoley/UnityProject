using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item_UI : MonoBehaviour
{
    public TMP_Text text;
    Item item;

    public void Initialize(Item item)
    {
        text.text = item.name;
        this.item = item;
    }
}
