using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Item : MonoBehaviour
{
    [Header("Item Data")]
    public string itemName;
    public Sprite icon;
    public bool equippable = true;
    public GameObject prefab = null;

    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // left click
    void OnMouseDown() 
    {
        // null check
        if (inventory == null)
        {
            Debug.LogWarning("No Inventory found in scene.");
            return;
        }

        InventoryItem item = new InventoryItem(itemName, icon, equippable, prefab);
        bool added = inventory.AddItem(item);

        if (added)
            Destroy(gameObject); // remove from world space when picked up
    }

    void OnMouseOver()
    {
        inventory.Hover(true);
    }

    void OnMouseExit()
    {
        inventory.Hover(false);
    }

}