using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InventoryScript inventoryScript;
    [SerializeField] PlaceableObject testObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryScript.DisplayInventory();
        }

        
        //test function
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlaceableObject test = Instantiate(testObject);
            
            inventoryScript.AddItem(test);


            
        }
    }

   
}
