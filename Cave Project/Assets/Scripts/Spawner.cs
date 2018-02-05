using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Use this for initialization

	public GameObject enemy, food, battery;
	public Transform [] enemySpawnPoints = new Transform [3];
	public Transform [] foodSpawnPoints = new Transform [3];
	public Transform [] batterySpawnPoints = new Transform [3];
	void Start () {
		spawnBattery();
		spawnFood();
		if (LevelManager.instance.currentLevel>1) {
			spawnEnemy();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void spawnEnemy () {
		for (int x = 0; x < 3 ; x++)
		Instantiate (enemy, enemySpawnPoints[x].position, enemySpawnPoints[x].rotation);
	}	

	void spawnFood () {
		Debug.Log ("Spawning");
		for (int x = 0; x < 3 ; x++)
		Instantiate (food, foodSpawnPoints[x].position, foodSpawnPoints[x].rotation);
	}

	void spawnBattery () {
		for (int x = 0; x < 3 ; x++)
		Instantiate (battery, batterySpawnPoints[x].position, batterySpawnPoints[x].rotation);
	}
}
