using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Use this for initialization

	public GameObject enemy, food, battery;
	public Transform [] enemySpawnPoints ;
	public Transform [] foodSpawnPoints ;
	public Transform [] batterySpawnPoints;
	void Start () {
		spawnBattery();
		spawnFood();
		spawnEnemy();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void spawnEnemy () {
		for (int x = 0; x < enemySpawnPoints.Length ; x++)
			Instantiate (enemy, enemySpawnPoints[x].position, enemySpawnPoints[x].rotation);
	}	

	void spawnFood () {
		Debug.Log ("Spawning");
		for (int x = 0; x < foodSpawnPoints.Length; x++)
			Instantiate (food, foodSpawnPoints[x].position, foodSpawnPoints[x].rotation);
	}

	void spawnBattery () {
		for (int x = 0; x < batterySpawnPoints.Length ; x++)
			Instantiate (battery, batterySpawnPoints[x].position, batterySpawnPoints[x].rotation);
	}
}
