using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id = 0;
    public string name = "";

    public Item(int id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
