using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization

	public int damage = 1;
	bool enemyNear; 
	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Enemy")){
			
			if (Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log ("Attacking enemy");

			}
		}
	}
}
