using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
	Animator animator;
	public int health = 20;
	void Start () {
		animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("ENEMY HEALTH: " + health);
		if (health==0)
			animator.SetTrigger("isDead");
	}

	public void takeDamage(int damage) {
		if (health>=1) {
			health-=damage;
		}
	}

	public void Die () {
		Debug.Log ("DYING");
		//play death animation
		Destroy(gameObject);
		//Destroy
	}

}
