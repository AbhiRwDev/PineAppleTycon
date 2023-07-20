using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

	public Image icon;
	public Button removeButton;
	public TextMeshProUGUI countText;
	Item item;  // Current item in the slot
    private void Update()
    {   
		
		
	}
    // Add item to the slot
    public void AddItem(Item newItem)
	{
		item = newItem;
		
	    countText.text = item.count.ToString();
		

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	// Clear the slot
	public void ClearSlot()
	{
		item = null;
		countText.text = " ";
		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory()
	{
		Inventory.instance.Remove(item);
		
	}

	// Use the item
	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}

}