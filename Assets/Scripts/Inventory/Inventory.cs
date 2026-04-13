using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    #region Public Variables
    public Image[] slots;           
    public Sprite emptySlotSprite;  
    public Sprite hungryCatSprite;

    #endregion
    [SerializeField]
    public InventoryItem[] items = new InventoryItem[3];
    private int hoveringSlot = -1;

    // add NEWITEM to inventory. Returns true on success and false if inventory is full
    public bool AddItem(InventoryItem newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                UpdateSlotUI(i);
                return true; 
            }
        }
        Debug.Log("Inventory full");
        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        items[slotIndex] = null;
        UpdateSlotUI(slotIndex);
    }

    public void Hover(bool isHovering)
    {
        if (isHovering)
        {
            if (hoveringSlot == -1)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] == null)
                    {
                        hoveringSlot = i;
                        slots[i].sprite = hungryCatSprite;
                        break;
                    }
                }
            }
        }
        else
        {
            if (hoveringSlot != -1) // guard against -1 index crash
            {
                UpdateSlotUI(hoveringSlot); // ← restores item icon OR empty sprite correctly
                hoveringSlot = -1;
            }
        }
    }

    void UpdateSlotUI(int slotIndex)
    {
        if (items[slotIndex] != null)
            slots[slotIndex].sprite = items[slotIndex].icon;
        else
            slots[slotIndex].sprite = emptySlotSprite;
    }

    public void UseItem(int slotIndex)
    {
        Debug.Log("slot index" + slotIndex);
        
        InventoryItem item = items[slotIndex];
        Debug.Log("item: " + item);
        Debug.Log("item: " + items[slotIndex]);

        if (item != null && item.equippable)
        {
            Debug.Log($"Using {item.itemName}");
            Debug.Log($"Item prefab: {item.prefab}");
            GameObject player = GameObject.FindWithTag("Player");
            Debug.Log($"Player found: {player != null}");
            if (player != null && item.prefab != null)
            {
                player.GetComponent<PlayerBehaviour>().EquipItem(item.prefab);
                
            }
            else
            {
                Debug.LogWarning("Player or item prefab not found. Cannot use item.");
            }
        }
    }

}