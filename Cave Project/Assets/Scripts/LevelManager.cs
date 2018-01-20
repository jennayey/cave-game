using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	float waitTime = 3f;
	public Text flashlightStatus, toast;
	[HideInInspector] public string toastText;
	public static LevelManager instance=null;	
	[HideInInspector] public bool playerCanMove;
	public float batteryLife;
	
	public int foodCount, rKey, sKey;
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
		batteryLife = 20f;
		//Get title up
	}
	// Use this for initialization
	void Start () {
		spawnEnemy();
		
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		flashlightStatus = GameObject.Find("Flashlight Text").GetComponent<Text>();
		toast = GameObject.Find("Toast").GetComponent<Text>();
		waitTime = 3f;
	}

	void assignLadderPoints () {
		//asign level shit;
	}

	void spawnEnemy () {
		for (int x = 0; x < 3 ; x++)
		Instantiate (enemy, enemySpawnPoints[x].position, enemySpawnPoints[x].rotation);
	}	
	// Update is called once per frame
	void Update () {
		if (batteryLife<=0f) {
			toastText = "You don't have batteries";
			setToastText();
		}
		setFlashlightStatusText ();
		waitTime = Mathf.MoveTowards(waitTime,0f, Time.deltaTime);
		Debug.Log ("wait: " + waitTime);
		if (waitTime == 0f) {
			toastText = " ";
			setToastText();
		}
	}

	public void addBatteryTime () {
		toastText = "You acquired battery!";
		batteryLife +=5f;
		setToastText();
	}

	public void setToastText (){
		toast.text = toastText;
		waitTime = 3f;
	}

	void setFlashlightStatusText (){
		flashlightStatus.text ="BATTERY STATUS: " + batteryLife.ToString("F0")+"s LEFT";
	}

	public void addSpcKey (){
		toastText = "You acquired a Special Key!";
		setToastText();
		sKey++;
	}
	public void addRegKey (){
		toastText = "You acquired a Key!";
		setToastText();
		rKey++;
	}

	public void addFoodCount (){
		toastText = "You acquired a Food Bar!";
		setToastText();
		foodCount++;
	}


}
