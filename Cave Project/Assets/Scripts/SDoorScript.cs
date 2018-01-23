﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDoorScript : MonoBehaviour {

	// Use this for initialization
	
	[HideInInspector] public bool opened, CanOpen;

	bool hasKey;
	// Use this for initialization
	void Start () {
		CanOpen = false;
		opened = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("CanOpen " + CanOpen);
		if (opened) {
			LevelManager.instance.toastText = " ";
			LevelManager.instance.setToastText();
		}
			
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("NEAR DOOR");
			
				if (LevelManager.instance.sKey>0) {
					CanOpen =true;


				}
				else if (LevelManager.instance.sKey==0 && !opened){
					CanOpen =false;
				}
			
		}
	}
}
