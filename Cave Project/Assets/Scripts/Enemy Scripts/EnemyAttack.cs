using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


	public int damage = 1;
	public int playerDamage = 5;
	bool playerNear;
	Animator animator; //reference
	GameObject player;
	
	EnemyHealth enemyHealth;
	public PlayerHealth playerHealth;
	void Awake () {
		enemyHealth = GetComponentInParent<EnemyHealth>();
		player = GameObject.FindGameObjectWithTag("Player");

		if (player == null) {
			Debug.Log ("PLAYER IS NULL");
		}

		else {
			Debug.Log ("PLAYER IS NOT NULL");
		}
		playerHealth = player.GetComponent<PlayerHealth>();
		animator = GetComponentInParent<Animator>();
	
	}

	void Start () {
		
	}
	void Update () {
		if (playerNear&&enemyHealth.health!=0 && playerHealth.health!=0) {
			//attack script here
				//attack here
				animator.SetTrigger ("playerNearBro"); 
				Debug.Log ("Attacking Player");	
		}

	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")){
				//add animation event after animation to run a code
				playerNear = true;
		}
		if (other.gameObject.CompareTag("playerWeapon")&& enemyHealth.health>0) {
			enemyHealth.takeDamage(playerDamage);
			animator.SetTrigger("isAttacked");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")){
			Debug.Log ("FAR Player");

				//add animation event after animation to run a code
				playerNear = false;	
		}
	}

	public void AttackPlayer () {
		playerHealth.takeDamage(damage);
	}

}
