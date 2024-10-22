using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : InventoryObject
{
	[SerializeField] public GameObject placePrefab;
	[SerializeField] public Vector3 size;
	[SerializeField] GameObject interactUI;
	[SerializeField] InteractionScript interactScript;

	bool placed = false;
	bool playerNear = false;
	bool uiOpen = false;
	GameObject currentUI;

	private void Update()
	{
		if (playerNear && Input.GetKeyUp(KeyCode.E))
		{
			if (!uiOpen)
			{
				currentUI = Instantiate(interactUI, FindFirstObjectByType<Canvas>().transform);
				interactScript.SetupUI(currentUI);
				uiOpen = true;
			}
			else
			{
				Destroy(currentUI);
				uiOpen = false;
			}

		}
	}


	public void Place()
	{
		//play placing animation
		
		placed = true;
	}


	private void OnTriggerEnter(Collider other)
	{
		if (placed && other.tag == "Player")
		{
			//display control pop up?
			playerNear = true;
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if(placed &&  other.tag == "Player")
		{
			//remove contol pop up

			if(currentUI != null)
			{
				Destroy(currentUI);
				uiOpen=false;
			}

			playerNear = false;
		}
	}
}
