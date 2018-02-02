using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 


public class exit : MonoBehaviour {

Transform pMovement;
PlayerMovement playerMovement;
public string levelname;
	// Use this for initialization
	void Start () {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		

	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			
			SceneManager.LoadScene(levelname);
			LevelManager.instance.currentLevel++;
			playerMovement.newLevelStart();
			
		}
	}
}
