using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoor : MonoBehaviour {

	// Use this for initialization
	SecondaryDoor secondaryDoor;
	public string text;
	public bool canOpen;

	
	void Start () {
		secondaryDoor = GetComponentInChildren<SecondaryDoor>();
		canOpen= false;
		text="You don't have keys to open this door";
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		Debug.Log ("on door");
		if (other.gameObject.CompareTag ("Player")) {
			if (Input.GetKeyDown (KeyCode.V)) {
				Debug.Log ("PRESSING V");
				if (LevelManager.instance.rKey>0 ){
					if (!secondaryDoor.opened) {
						canOpen=true;
					}
						
						// secondaryDoor.setDoorToOpen();

				}
				else {
					Debug.Log ("No key");
					//toast text to
					canOpen= false;
					LevelManager.instance.toastText = text;
					LevelManager.instance.setToastText();

				}
			}
		}
	}
}
