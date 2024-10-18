using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
 

public class InventoryScript : MonoBehaviour
{
	[SerializeField] GameObject slotPrefab;
	[SerializeField] GameObject inventoryUI;
	[SerializeField] GameObject hotbarUI;
	[SerializeField] int inventoryHeight = 3;
	[SerializeField] int inventoryWidth = 10;

	InventoryObject[,] inventory;
	List<InventorySlot> inventorySlots;
	List<InventorySlot> hotbarSlots;

	Vector2 position1;
	bool selected = false;

	int hotBarSelection = 5;
	bool validSelection = false;
	GameObject placeable;

	private void Start()
	{
		inventory = new InventoryObject[inventoryHeight, inventoryWidth];
		inventorySlots = new List<InventorySlot>(inventoryHeight * inventoryWidth);
		hotbarSlots = new List<InventorySlot>(5);
		DrawInventory(inventory);
	}

	private void MoveItem(int xPosition, int yPosition, int newXPos, int newYPos)
	{
		
		InventoryObject temp = inventory[newYPos, newXPos];
		
		inventory[newYPos, newXPos] = inventory[yPosition, xPosition];

		inventory[yPosition, xPosition] = temp;

		
		DrawInventory(inventory);
	}

	public void RemoveItem(int xPosition, int yPosition)
	{
		if(inventory[yPosition, xPosition] != null)
		{
			inventory[yPosition, xPosition].numberOfItems --;

			if (inventory[yPosition, xPosition].numberOfItems == 0)
			{
				inventory[yPosition, xPosition] = null;
			}
		}
		DrawInventory(inventory);
	}

	public void AddItem(InventoryObject item)
	{
		int x = 0;
		int y = 0;
		bool nullFound = false;

		for (int i = 0; i < inventoryHeight ; i++)
		{
			for (int j = 0; j < inventoryWidth; j++)
			{
				if(inventory[i, j] != null)
				{
					if (item.DisplayName.Equals(inventory[i, j].DisplayName))
					{
						if (inventory[i, j].numberOfItems != inventory[i, j].MaxNumber)
						{
							inventory[i,j].numberOfItems++;
							DrawInventory(inventory);
							return;
						}
					}
				}
				if (inventory[i,j] == null && !nullFound)
				{
					x= i; y= j;
					nullFound = true;
				}
			}
		}

		inventory[x, y] = item;
		inventory[x, y].numberOfItems++;
		DrawInventory(inventory);
		return;
	}



	public void DisplayInventory()
	{
		if (inventoryUI.activeSelf)
		{
			inventoryUI.SetActive(false);
		}
		else
		{
			DrawInventory(inventory);
			inventoryUI.SetActive(true);
		}
		
	}

	void CreateInventorySlot()
	{
		GameObject newSlot = Instantiate(slotPrefab);
		newSlot.transform.SetParent(inventoryUI.transform, false);

		InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
		newSlotComponent.ClearSlot();

		inventorySlots.Add(newSlotComponent);
	}
	void CreateHotBarSlot()
	{
		GameObject newSlot = Instantiate(slotPrefab);
		newSlot.transform.SetParent(hotbarUI.transform, false);

		InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
		newSlotComponent.ClearSlot();

		hotbarSlots.Add(newSlotComponent);
	}

	void ResetInventory()
	{
		foreach (Transform childTransform in inventoryUI.transform)
		{
			Destroy(childTransform.gameObject);
		}
		inventorySlots = new List<InventorySlot>(inventoryHeight * inventoryWidth);
	}	
	void ResetHotbar()
	{
		foreach (Transform childTransform in hotbarUI.transform)
		{
			Destroy(childTransform.gameObject);
		}
		hotbarSlots = new List<InventorySlot>(5);
	}

	void DrawInventory(InventoryObject[,] inventory)
	{
		ResetInventory();

		for (int i = 0; i < inventorySlots.Capacity; i++)
		{
			CreateInventorySlot();
		}
		for( int i = 0; i < inventoryHeight; i++)
		{
			for(int j = 0; j <inventoryWidth; j++)
			{
				inventorySlots[(i * 10) + j].slotNumber = new Vector2(j,i);
			}
		}
		
		for (int i = 0; i < inventoryHeight; i++)
		{
			for (int j = 0; j < inventoryWidth; j++)
			{
				inventorySlots[(i * 10) + j].DrawSlot(inventory[i, j]);
			}
		}

		ResetHotbar();

		for (int i = 0; i < hotbarSlots.Capacity; i++)
		{
			CreateHotBarSlot();
			hotbarSlots[i].DrawSlot(inventory[0, i]);
		}

	}

	

	public void SelectItem(Vector2 position)
	{
		
		if(!selected)
		{
			position1.x = position.x;
			position1.y = position.y;
			Debug.Log("x: " + position.x);
			Debug.Log("y: " + position.y);
			Debug.Log(((position.y * 10) + position.x));
			inventorySlots[(int)((position.y * 10) + position.x)].selector.enabled = true;
			selected = true;
		}
		else
		{
			MoveItem((int)position1.x, (int)position1.y, (int)position.x, (int)position.y);
			selected = false;
		}
		DrawInventory(inventory);
	}

	private void Update()
	{
		

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			hotBarSelection = 0;
			if (placeable != null)
			{
				Destroy(placeable);
				validSelection = false;

			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			hotBarSelection = 1;
			if (placeable != null)
			{
				Destroy(placeable);
				validSelection = false;
			}

		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			hotBarSelection = 2;
			if (placeable != null)
			{
				Destroy(placeable);
				validSelection = false;
			}

		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			hotBarSelection = 3;
			if (placeable != null)
			{
				Destroy(placeable);
				validSelection = false;
			}

		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			hotBarSelection = 4;
			if (placeable != null)
			{
				Destroy(placeable);
				validSelection = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			hotBarSelection = 5;				
			if (placeable != null)
			{
				Destroy(placeable);
			}
			validSelection = false;
		
		}

		if (hotBarSelection < 5)
		{
			Debug.Log(1);
			if (inventory[0,hotBarSelection] != null && inventory[0, hotBarSelection].GetComponent<PlaceableObject>())
			{
				Debug.Log(2);

				if (!validSelection)
				{
					placeable = Instantiate<PlaceableObject>((PlaceableObject)inventory[0, hotBarSelection]).placePrefab;
					validSelection = true;

				}

				placeable.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.localPosition.z));

				if (Input.GetMouseButtonDown(0)) 
				{
					RemoveItem(0, hotBarSelection);
					validSelection = false;
				}
			}
		}
	}
}
