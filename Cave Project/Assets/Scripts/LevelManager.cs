using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	Text [] itemList = new Text [4];
	CanvasGroup itemUI;
	public Slider batterySlider;
	float waitTime = 3f;
	public Text  toast;
	[HideInInspector] public string toastText;
	public static LevelManager instance=null;	
	[HideInInspector] public bool playerCanMove;
	public float batteryLife;
	
	public int foodCount, rKey, sKey,batteryCount;
	public GameObject enemy;
	PlayerMovement player;
	private int loadingScreenUp;
	int currentLevel;
	int numberOfEnemies;
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
		//Get title up
	}
	// Use this for initialization
	void Start () {
		spawnEnemy();
		itemUI = GameObject.Find("ItemsUI").GetComponent<CanvasGroup>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		// flashlightStatus = GameObject.Find("Flashlight Text").GetComponent<Text>();
		toast = GameObject.Find("Toast").GetComponent<Text>();
		
		waitTime = 3f;

		itemUI.alpha =0;

		itemList[0] = GameObject.Find("rKeyUIText").GetComponent<Text>();
		if ( itemList[0]!=null) {
			Debug.Log ("text is not null");
		}
		itemList[1] = GameObject.Find("sKeyUIText").GetComponent<Text>();
		itemList[2] = GameObject.Find("foodUIText").GetComponent<Text>();
		itemList[3] = GameObject.Find("batteryUIText").GetComponent<Text>();
	}

	void assignLadderPoints () {
		//asign level shit;
	}
	void spawnEnemy () {
		// for (int x = 0; x < 3 ; x++)
//		Instantiate (enemy, enemySpawnPoints[x].position, enemySpawnPoints[x].rotation);
	}	
	// Update is called once per frame
	void Update () {

		batterySlider.value = batteryLife;
		// setFlashlightStatusText ();
		waitTime = Mathf.MoveTowards(waitTime,0f, Time.deltaTime);
		// Debug.Log ("wait: " + waitTime);
		if (waitTime == 0f) {
			toastText = " ";
			setToastText();
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			itemUI.alpha =1;
		}
		if (Input.GetKeyUp (KeyCode.Tab)) {
			itemUI.alpha =0;
		}
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
		itemList[0].text = rKey.ToString();
		//Debug.Log ("R KEY IS " + itemList[0].text );	
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
