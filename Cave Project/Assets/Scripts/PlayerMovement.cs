﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public Text flashlightStatus, toast;
	public float speed;
	private int rotateFace = 180;
	private Rigidbody2D rb2d;
	private Vector2 tryMove;
	private Animator animator;
	private Transform lightChild;
	private string toastText;
	private float batteryLife = 0f; // PUT IN GAME MANAGER
//	private int carriedBattery = 0; // PUT IN GAME MANAGER
	private Vector3 flashlightSize;

	public GameObject start, start2;
	
	// Use this for initialization
	
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent <Animator>();
		//start = GetComponent<GameObject>();
		//start2 = GetComponent<GameObject>();
		//initialize flashlight size
		flashlightStatus = GameObject.Find("Flashlight Text").GetComponent<Text>();
		toast = GameObject.Find("Toast").GetComponent<Text>();
		flashlightSize = new Vector3 (2,2,0);
		lightChild= transform.Find ("Flashlight");
		batteryLife = 10f;

		if (lightChild!= null) {
			Debug.Log ("Found Child");

			if (lightChild.gameObject.activeInHierarchy !=true) {
				lightChild.gameObject.SetActive (true);
			}
			lightChild.gameObject.transform.localScale = flashlightSize;
		}
		else 
			Debug.Log ("Not found");
		
		if (start != null){
			Debug.Log ("GameObject Found");
			transform.position = start.gameObject.transform.position;
		}
		else
			Debug.Log ("GameObject not Found");	
	}
	// Update is called once per frame
	void Update () {
		//sets the character movement to zero
		tryMove = Vector2.zero;
		
		//move left
		if (Input.GetKey (KeyCode.A)) {
			tryMove += Vector2Int.left;
			transform.localEulerAngles = new Vector2 (transform.rotation.x, rotateFace);
		}
		//move right
		if (Input.GetKey (KeyCode.D)) {
			tryMove += Vector2Int.right;
			transform.localEulerAngles = new Vector2 (transform.rotation.x, 0); //zero faces back to original
		}
		//move up
		if (Input.GetKey (KeyCode.W))
			tryMove += Vector2Int.up;
		//move down
		if (Input.GetKey (KeyCode.S))
			tryMove += Vector2Int.down;	
		//player attack
		if (Input.GetKeyDown (KeyCode.Space)) 
			animator.SetTrigger ("playerAttack");
		//Lights turn on
		if (Input.GetKey(KeyCode.LeftShift)){
			if (batteryLife<=0f){
				toastText = "YOU DON'T HAVE BATTERIES";
				setToastText();
				//Debug.Log ("You don't have batteries");
				reducePower();
			}
			else {
				addLightPower();
				batteryLife = Mathf.MoveTowards (batteryLife, 0f ,Time.deltaTime);
			}	
		}
		//light turn off	
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			reducePower();
			toastText=" ";
			setToastText();
		}

		
		
	}
	
	void FixedUpdate () {
		//if character is moving, set the animation
		if (rb2d.velocity.magnitude > 0)
			animator.SetBool ("playerRun", true);
		else 
			animator.SetBool ("playerRun", false);
		//clamps the movement so it doesn't slide 
		rb2d.velocity = Vector2.ClampMagnitude(tryMove, 1f) * speed;
		Debug.Log ("Bttery Left is " + batteryLife);
		setFlashlightStatusText ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		//if collides with food
		if (other.gameObject.CompareTag ("Food")) {
			other.gameObject.SetActive (false);
			batteryLife +=2f;
			//Debug.Log ("You acquired battery");
			toastText = "YOU ACQUIRED BATTERY";
			setToastText();
				
		}
		//collision with exit object
		if (other.gameObject.CompareTag ("Exit")) {
			Debug.Log ("Collided with exit");
			transform.position =  start2.transform.localPosition;
		}
	}
	void addLightPower () {
				lightChild.gameObject.transform.localScale = new Vector3(5,5,0);
	}
	void reducePower () {
				lightChild.gameObject.transform.localScale = new Vector3(2,2,0);
	}

	void setFlashlightStatusText (){
		flashlightStatus.text ="BATTERY STATUS: " + batteryLife.ToString("F0")+"s LEFT";
	}

	void setToastText (){
		toast.text = toastText;
	}
}
