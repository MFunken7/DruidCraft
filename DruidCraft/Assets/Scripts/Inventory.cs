using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class InventoryScript : MonoBehaviour
{
	[SerializeField] GameObject inventoryUI;
	[SerializeField] int inventoryHeight = 3;
	[SerializeField] int inventoryWidth = 10;

	InventoryObject[,] inventory;

	private void Start()
	{
		inventory = new InventoryObject[inventoryHeight, inventoryWidth];
	}

	void MoveItem(int xPosition, int yPosition, int newXPos, int newYPos)
	{
		if (inventory[newXPos, newYPos] == null)
		{
			InventoryObject temp = inventory[xPosition, yPosition];

			inventory[xPosition, yPosition] = null;

			inventory[newXPos, newYPos] = temp;
		}
	}

	void RemoveItem(int xPosition, int yPosition)
	{
		if(inventory[xPosition, yPosition] != null)
		{
			inventory[xPosition, yPosition].numberOfItems --;

			if (inventory[xPosition,yPosition].numberOfItems == 0)
			{
				inventory[xPosition, yPosition] = null;
			}
		}
	}


	public void DisplayInventory()
	{
		if (inventoryUI.active)
		{
			inventoryUI.SetActive(false);
		}
		else
		{
			inventoryUI.SetActive(true);
		}
		
	}

	void UpdateInventory()
	{
		
	}


}
