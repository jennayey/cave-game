using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Vector2[] start = new Vector2 [6];
	Vector2 startHere;
	Text [] itemList = new Text [4];
	CanvasGroup itemUI;
	public Slider batterySlider;
	float waitTime = 3f;
	public Text  toast;
	[HideInInspector] public string toastText;
	public static LevelManager instance=null;	
	public float batteryLife;
	
	public int foodCount, rKey, sKey,batteryCount;
	public GameObject enemy;
	PlayerMovement player;
	public int currentLevel;

//	Transform [][] enemySpawnPoints = new Transform [6][];
	public Transform [] enemySpawnPoints = new Transform [3];
	Transform [,] ladderPoints = new Transform [6,3];

	void Awake () {
		if (instance ==null) {
			instance =this;
		}
		else if (instance!=this) {
			Destroy(gameObject);
		}
		batteryLife = 60f;

		currentLevel = 0;

		//Get title up
	}
	// Use this for initialization
	void Start () {
		itemUI = GameObject.Find("ItemsUI").GetComponent<CanvasGroup>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		// flashlightStatus = GameObject.Find("Flashlight Text").GetComponent<Text>();
		toast = GameObject.Find("Toast").GetComponent<Text>();
		//WAIT TIME FOR DISPLAYING TOAST TEXT
		waitTime = 3f;
		//PRESS TAB TO HIDE AND SHOW UI
		itemUI.alpha =0;
//=======================================================================================================================================
		//GET UI 
		itemList[0] = GameObject.Find("rKeyUIText").GetComponent<Text>();
		itemList[1] = GameObject.Find("sKeyUIText").GetComponent<Text>();
		itemList[2] = GameObject.Find("foodUIText").GetComponent<Text>();
		itemList[3] = GameObject.Find("batteryUIText").GetComponent<Text>();

//=======================================================================================================================================
		//SET START POINTS
		start[0] = new Vector2 (45,12);
		start[1] = new Vector2 (1,1);
	
	}

	void Update () {
		//BATTERY STATUS
		batterySlider.value = batteryLife;
		//COUNTDOWN OF TIMER 
		waitTime = Mathf.MoveTowards(waitTime,0f, Time.deltaTime);
		if (waitTime == 0f) {
			toastText = " ";
			setToastText();
		}
		//PRESS TAB TO HIDE AND SHOW UI
		if (Input.GetKeyDown (KeyCode.Tab)) {
			itemUI.alpha =1;
		}
		if (Input.GetKeyUp (KeyCode.Tab)) {
			itemUI.alpha =0;
		}

		//USE BATTERIES
		if (Input.GetKeyDown (KeyCode.R)) {
		
			if (batteryCount==0) {
				toastText = "You don't have batteries";
				setToastText();
			}
			else if (batteryCount>0) {
				addBatteryTime();
				batteryCount--;
			}
		}

		//USE FOOD BARS
		if (Input.GetKeyDown (KeyCode.E)) {
			if (foodCount==0) {
				toastText = "You don't have food bars";
				setToastText();
			}

			else if (foodCount>0) {
				addHealth();
				foodCount--;
			}
		}

		if (rKey<0 || sKey<0) {
			rKey=0;
			sKey=0;
		}

		//UPDATE UI 
		itemList[0].text = rKey.ToString();
		itemList[1].text = sKey.ToString();
		itemList[2].text = foodCount.ToString();
		itemList[3].text = batteryCount.ToString();

		
	}

	public void addBattery() {
		batteryCount++;
		toastText = "You acquired battery!";
		
		setToastText();
		// Debug.Log ("Batt count " + batteryCount);
	}
	public void addBatteryTime () {	
		batteryLife +=5f;
	}
	public void addFoodCount (){
		foodCount++;
		toastText = "You acquired a Food Bar!";
		setToastText();	
	}
	public void addHealth () {
		player.eatFood();
	}
	public void setToastText (){
		toast.text = toastText;
		waitTime = 3f;
	}
	// void setFlashlightStatusText (){
	// 	flashlightStatus.text ="BATTERY STATUS: " + batteryLife.ToString("F0")+"s LEFT";
	// }
	public void addSpcKey (){
		sKey++;
		toastText = "You acquired a Special Key!";	
		
		setToastText();
		
	}
	public void addRegKey (){
		rKey++;	
		toastText = "You acquired a Key!";
		setToastText();
			
		Debug.Log ("Key count " + rKey);
	}

}
