﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryDoor : MonoBehaviour {

	// Use this for initialization

	public bool opened, canOpen;
	MainDoor mainDoor;
	Animator animator;
	void Start () {
		mainDoor= GetComponentInParent<MainDoor>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mainDoor.canOpen&&!opened){
			setDoorToOpen();
		}
	
		
	}

	public void setDoorToOpen () {
		//animator set to opening state 
		animator.SetTrigger ("canOpenDoor");
		//animator set to opened state 
		animator.SetBool("hasOpened", true);
		opened = true;
		LevelManager.instance.rKey--;
		//set bool to opened
		mainDoor.text=" ";
		
	}
}
