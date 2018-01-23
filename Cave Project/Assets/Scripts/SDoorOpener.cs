using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDoorOpener : MonoBehaviour {

	// Use this for initializationpublic int rotateValue;
	SDoorScript doorScriptRef;
	bool hasOpened;
	Animator animator;
	public string kindOfKey;
	// Use this for initialization
	void Start () {
		hasOpened=false;
		doorScriptRef = GetComponentInParent<SDoorScript>();
		animator = GetComponent <Animator>();
		kindOfKey = "rKey";
	}

	void Update () {

			if (doorScriptRef.CanOpen) {
				if (!hasOpened) {
					if (Input.GetKey (KeyCode.V)) {
						hasOpened = true;
						openDoor ();
					}
					
				}
					
			}

			else if (!doorScriptRef.CanOpen && hasOpened!=true) {

			
					if (Input.GetKey (KeyCode.V)) {
						Debug.Log ("HAsopened " + hasOpened);
						LevelManager.instance.toastText = "You don't have keys to open this door";
						LevelManager.instance.setToastText();
					}
				
			} 

			else if (hasOpened) {

					if (Input.GetKey (KeyCode.V)) {
						LevelManager.instance.toastText = " ";
						LevelManager.instance.setToastText();
					}
			}

		
	}
	void HasOpened () {
		animator.SetBool ("hasOpened", true);
		LevelManager.instance.sKey--;
		doorScriptRef.opened = true;
		
	}
	
	void openDoor (){
		if 	(doorScriptRef.CanOpen) {
			animator.SetTrigger ("canOpenDoor");
			Debug.Log ("Player CAN OPEN Door"); 
			hasOpened = true;
			doorScriptRef.opened = true;
			
		}
	}
}
