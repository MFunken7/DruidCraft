using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TestInteractions : InteractionScript
{
	GameObject connectedUI;
	int numberOfTimesClicked = 0;
	UnityAction action;

	private void Start()
	{
		action += Interaction;	
	}

	public override void SetupUI(GameObject UI)
	{
		connectedUI = UI;
		UI.GetComponentInChildren<Button>().onClick.AddListener(action);
		UI.GetComponentInChildren<TextMeshProUGUI>().text = ("Clicked: " + numberOfTimesClicked);

	}


	void Interaction()
	{
		numberOfTimesClicked++;
		connectedUI.GetComponentInChildren<TextMeshProUGUI>().text = ("Clicked: " + numberOfTimesClicked);
	}



}
