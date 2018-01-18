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
		
	}

	void takeDamage(int damage) {
		if (health>=1) {
			health-=damage;
		}
		else if (health==0){
			Die();
		}
	}

	void Die () {
		//play death animation
		animator.SetTrigger("isDead");
		//Destroy
	}
}
