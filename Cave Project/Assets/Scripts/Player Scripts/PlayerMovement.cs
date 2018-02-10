using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
	#region Variables
	// public Text flashlightStatus, toast;
	
	public AudioClip pickUpSFX;
	public AudioClip pickUpUSE;

	PlayerHealth playerHealth;
	public float speed;
	// private int damageAttack;
	private int foodValue = 20;
	private int rotateFace = 180;
	private Rigidbody2D rb2d;
	private Vector2 tryMove;
	private Animator animator;
	private Transform lightChild;
	private float batteryLife = 0f; // PUT IN GAME MANAGER
//	private int carriedBattery = 0; // PUT IN GAME MANAGER
	private Vector3 flashlightSize;
	Vector2 start;
	#endregion
	// Use this for initialization
	void Start () {
		start = GameObject.FindGameObjectWithTag("Start").gameObject.transform.position;
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent <Animator>();
		//start = GetComponent<GameObject>();
		//start2 = GetComponent<GameObject>();
		//initialize flashlight size
		// spRenderer= GetComponent<SpriteRenderer>();
		playerHealth = GetComponent <PlayerHealth>();
		flashlightSize = new Vector3 (2,2,0);
		lightChild= transform.Find ("Flashlight");
		start = GameObject.FindGameObjectWithTag("Start").transform.position;
		transform.position = start;
		Debug.Log ("GameObject START Found");
		// damageAttack = 10;

		if (lightChild!= null) {
			 Debug.Log ("Found Child");

			if (lightChild.gameObject.activeInHierarchy !=true) {
				lightChild.gameObject.SetActive (true);
			}
			lightChild.gameObject.transform.localScale = flashlightSize;
		}
	}
	// Update is called once per frame
	void Update () {
		
		//sets the character movement to zero
		tryMove = Vector2.zero;
		batteryLife = LevelManager.instance.batteryLife;
	
		
		if (!PauseMenu.gameIsPaused) {
			if (Input.GetKeyUp(KeyCode.Space)) {
				animator.SetTrigger ("playerAttack");
				// spRenderer.color = Color.red;
				//spRenderer.color = Color.white;
			}
			//move left
			if (Input.GetKey (KeyCode.LeftArrow)) {
				tryMove += Vector2Int.left;
				transform.localEulerAngles = new Vector2 (transform.rotation.x, rotateFace);
			}
			//move right
			if (Input.GetKey (KeyCode.RightArrow)) {
				tryMove += Vector2Int.right;
				transform.localEulerAngles = new Vector2 (transform.rotation.x, 0); //zero faces back to original
			}
			//move up
			if (Input.GetKey (KeyCode.UpArrow))
				tryMove += Vector2Int.up;
			//move down
			if (Input.GetKey (KeyCode.DownArrow))
				tryMove += Vector2Int.down;	
			//Lights turn on
			if (Input.GetKey(KeyCode.LeftShift)){
				Debug.Log ("Shift Down");
				if (batteryLife<=0f){
					LevelManager.instance.toastText = "You don't have batteries";
					LevelManager.instance.setToastText();
					reducePower();
				}
				else if (batteryLife >0) {
					addLightPower();
					
					LevelManager.instance.batteryLife = Mathf.MoveTowards (batteryLife, 0f ,Time.deltaTime);
				}	
			}
			//light turn off	
			if (Input.GetKeyUp(KeyCode.LeftShift)) {
				reducePower();	
			}
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
		// Debug.Log ("Battery Left is " + batteryLife);
	}

	void OnTriggerEnter2D (Collider2D other) {
		//if collides with food
		if (other.gameObject.CompareTag ("Battery")) {
			other.gameObject.SetActive (false);
			LevelManager.instance.addBattery();
			SoundManager.instance.PlaySingle(pickUpSFX);
		}
		else if (other.gameObject.CompareTag ("Food")) {
			other.gameObject.SetActive (false);
			LevelManager.instance.addFoodCount();
			SoundManager.instance.PlaySingle(pickUpSFX);
		}
		else if (other.gameObject.CompareTag ("Key_Reg")) {	
			other.gameObject.SetActive (false);
			LevelManager.instance.addRegKey();
			SoundManager.instance.PlaySingle(pickUpSFX);
		}
		else if (other.gameObject.CompareTag ("Key_Spc")) {
			other.gameObject.SetActive (false);
			LevelManager.instance.addSpcKey();
			SoundManager.instance.PlaySingle(pickUpSFX);
		}
		//collision with exit object
		
	}
	private void addLightPower () {
		lightChild.gameObject.transform.localScale = new Vector3(7,7,0);
	}
	private void reducePower () {
				lightChild.gameObject.transform.localScale = new Vector3(2,2,0);
	}
	public void eatFood (){
		if (LevelManager.instance.foodCount >0) {
			playerHealth.health+=foodValue;
			SoundManager.instance.PlaySingle(pickUpUSE);
		}
		else if (LevelManager.instance.foodCount ==0 ) {
			LevelManager.instance.toastText = "You don't have food anymore";
			LevelManager.instance.setToastText();
		}
	}

	public void newLevelStart () {
		switch (LevelManager.instance.currentLevel) {
			case 0: 
				transform.position = LevelManager.instance.start[0];
				break;
			case 1:
				transform.position = LevelManager.instance.start[1];
				break;
			case 2:
				transform.position = LevelManager.instance.start[2];
				break;
			case 3:
				transform.position = LevelManager.instance.start[3];
				break;
			case 4:
				transform.position = LevelManager.instance.start[4];
				break;
			case 5:
				transform.position = LevelManager.instance.start[5];
				break;

		}
	}
	
}
