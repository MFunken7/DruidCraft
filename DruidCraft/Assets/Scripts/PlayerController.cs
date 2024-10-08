using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InventoryScript inventoryScript;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryScript.displayInventory();
        }
    }

   
}
