using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControlelr : MonoBehaviour {
	ElevatorTrig accessor;
	public GameObject mCollider;
	bool canOpenElevator;
	bool elevatorIsOpen;
	Animator animator;
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator>();
		accessor = GetComponentInChildren<ElevatorTrig>();
		//checks if elevator is open
		elevatorIsOpen=false;
	}
	
	// Update is called once per frame
	void Update () {
		//checks ElevatorTrig script to check if Player is 
		//colliding with the collider
		if (accessor.enterTrigger!=false){
			canOpenElevator = true;
			Debug.Log ("CAN OPEN ELEVATOR");
		}

		else {
			canOpenElevator = false;
			Debug.Log ("CANNOT OPEN ELEVATOR");
		}
		//Checks if player can open the Elevator
		if (Input.GetKey(KeyCode.E)&&elevatorIsOpen!=true) {
			if (canOpenElevator !=false){
				animator.SetBool ("canOpen", true);
				elevatorIsOpen=true;
				mCollider.gameObject.SetActive(false);
			}
		}
		//checks if the plyer is away from the elevator
		else if (elevatorIsOpen!=false&&canOpenElevator!=true){
			animator.SetBool("canOpen", false);
			elevatorIsOpen=false;
			mCollider.gameObject.SetActive(true);
		}
	
	}
}
