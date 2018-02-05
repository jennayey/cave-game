using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPCMainDoor : MonoBehaviour {

	// Use this for initialization
	SPCSecondaryDoor secondaryDoor;
	public	string text;
	public bool canOpen;	
	void Start () {
		secondaryDoor = GetComponentInChildren<SPCSecondaryDoor>();
		// if (secondaryDoor!=null) {
		// 	Debug.Log ("SPC DOor is not null");
		// }
		// else 
		// 	Debug.Log ("SPC Door is null");	
		canOpen= false;
		text = "You don't have keys to open this door";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other) {
		Debug.Log ("on door");
		if (other.gameObject.CompareTag ("Player")) {
			if (Input.GetKeyUp (KeyCode.V)) {
				
				if (LevelManager.instance.sKey>0 ){
					Debug.Log ("PRESSING V");
					if (!secondaryDoor.opened) {
						canOpen=true;
					}
						
						// secondaryDoor.setDoorToOpen();

				}
				else {
					Debug.Log ("No key");
					//toast text to
					canOpen= false;
					LevelManager.instance.toastText = text ;
					LevelManager.instance.setToastText();

				}
			}
		}
	}
}
