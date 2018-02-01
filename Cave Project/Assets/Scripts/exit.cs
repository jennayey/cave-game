using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 


public class exit : MonoBehaviour {

	// Use this for initialization
void OnTriggerEnter2D (Collider2D other) {
	if (other.gameObject.CompareTag ("Player")) {
		
		SceneManager.LoadScene("Level1");
 
	}
}
}
