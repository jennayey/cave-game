using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPCSecondaryDoor : MonoBehaviour {

	// Use this for initialization
	public bool opened, canOpen;
	SPCMainDoor mainDoor;
	int x=1;
	Animator animator;
	void Start () {
		mainDoor= GetComponentInParent<SPCMainDoor>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainDoor.canOpen&&!opened){
			OpenDoor();
			// opened = true;
		}
	}

	public void setDoorToOpen () {
		
		//animator set to opened state 
		animator.SetBool("hasOpened", true);
		
	}

		void OpenDoor () {
		//animator set to opening state 
		animator.SetTrigger ("canOpenDoor");
		opened = true;
		LevelManager.instance.sKey--;
		//set bool to opened
		mainDoor.text=" ";
	}

	void ReduceKey () {
		if (x==1) {
			LevelManager.instance.rKey--;
			x++;
		}
		
	}
}
