using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InventoryScript inventoryScript;
    [SerializeField] PlaceableObject testObject;


    PlaceableObject test;

	private void Start()
	{
		test = Instantiate(testObject, new Vector3(0, -5, 0), Quaternion.identity);
	}


	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryScript.DisplayInventory();
        }

        
        //test function
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {            
            inventoryScript.AddItem(test);
        }
    }

   
}
