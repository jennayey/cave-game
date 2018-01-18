using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	public int health = 100;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Health " + health);
	}	

	public void takeDamage (int damage) {
		if (health>=1) {
			health-=damage;
		}

		if (health==0) {
			//dead//Dim screens
		}
	}

	void Die () {
		Debug.Log("Dead");
	}
}
