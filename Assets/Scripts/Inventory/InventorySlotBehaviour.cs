using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotBehaviour : MonoBehaviour, IPointerClickHandler
{

    public int slotIndex;
    private Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
        {

        // this should trigger for ANY click
        Debug.Log($"CLICK DETECTED on slot {slotIndex}!");

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click confirmed!");
            inventory.UseItem(slotIndex);
        }
        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click detected!");
        }
        
    }
}
