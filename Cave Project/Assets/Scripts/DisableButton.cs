using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class DisableButton : MonoBehaviour {

	// Use this for initialization
	public Button continueButton; 
	void Awake () {
		continueButton = GetComponent<Button>();
		if (continueButton.IsInteractable()==true) {
			continueButton.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (File.Exists(Application.persistentDataPath + "/gamesave.sv")) {
			continueButton.interactable = true;
		}
	}
}
