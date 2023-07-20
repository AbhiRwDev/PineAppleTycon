using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	 public delegate void ItemUsedHandler(Item item);
    public static event ItemUsedHandler OnItemUsed;

	new public string name = "New Item";    // Name of the item
	public Sprite icon = null;              // Item icon
	public bool showInInventory = true;
	public CurrentTool toolType;
	public int count=0;
	public int durability=5;


	
	// Called when the item is pressed in the inventory
	public virtual void Use()
	{
		Tool.instance.currentItem = this;
		// Use the item
		// Something may happen
		Debug.Log("Using "+ name);
		Tool.instance.toolType = toolType;
		
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory()
	{
		Inventory.instance.Remove(this);
	}

}