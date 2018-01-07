using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorTrig : MonoBehaviour {

	public Text openElevatorToast;
	public bool enterTrigger;
	string ElevatorToast = "PRESS 'E' TO OPEN THE ELEVATOR";

	// Use this for initialization
	void Start () {
		openElevatorToast = GameObject.Find("Toast").GetComponent<Text>();
		openElevatorToast.gameObject.SetActive(true);
		
	}
	
	// checks if player is colliding with trigger
	void OnTriggerEnter2D  (Collider2D other) {
	
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Collided with player");
			enterTrigger = true;
			openElevatorToast.text = ElevatorToast;
			openElevatorToast.gameObject.SetActive(true);
			
		}
	}
	//checks if the player has moved away from collider	
	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("UNCollided with player");
			enterTrigger = false;
			//openElevatorToast.gameObject.SetActive(false);
			openElevatorToast.text = " ";
		}
	}
}
