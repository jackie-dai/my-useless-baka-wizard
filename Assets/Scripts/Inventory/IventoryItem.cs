using UnityEngine;

public class InventoryItem
{
    public string itemName;
    public Sprite icon;

    public InventoryItem(string name, Sprite icon)
    {
        this.itemName = name;
        this.icon = icon;
    }
}