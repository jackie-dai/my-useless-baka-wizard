using UnityEngine;

public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public bool equippable;
    public GameObject prefab; 

    public InventoryItem(string name, Sprite icon, bool equippable, GameObject prefab)
    {
        this.itemName = name;
        this.icon = icon;
        this.equippable = equippable;
        if (equippable && prefab != null)
        {
            this.prefab = prefab;
        }
    }

    //void OnMouseDown()
    //{
    //    //on mouse down, equip item if possible
    //    if (equippable)
    //    {
    //        Debug.Log($"Equipped {itemName}");

    //        //add the prefab as a child to the player gameobject
    //        GameObject player = GameObject.FindWithTag("Player");
    //        if (player != null && prefab != null)
    //        {
    //            player.GetComponent<PlayerBehaviour>().EquipItem(prefab);
    //        } else
    //        {
    //            Debug.LogWarning("Player or prefab not found. Cannot equip item.");
    //        }
    //    }

    //}
}