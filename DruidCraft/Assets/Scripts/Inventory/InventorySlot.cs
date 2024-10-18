using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;
    public Image selector;
    InventoryScript inventory;
    public Vector2 slotNumber;

	private void Start()
	{
        GameObject player = GameObject.Find("Player");
		inventory = player.GetComponent<InventoryScript>();
        selector.enabled = false;
	}

	public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
        
    }

    public void DrawSlot(InventoryObject inventoryObject)
    {
        if (inventoryObject == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;

        icon.sprite = inventoryObject.icon;
        labelText.text = inventoryObject.DisplayName;
        stackSizeText.text = inventoryObject.numberOfItems.ToString();

    }

	public void OnPointerClick(PointerEventData eventData)
	{
        if (eventData.button == PointerEventData.InputButton.Left) 
        { 
            inventory.SelectItem(slotNumber);
        }

        if(eventData.button == PointerEventData.InputButton.Right)
        {
            inventory.RemoveItem((int)slotNumber.x, (int)slotNumber.y);
        }
	}
}
