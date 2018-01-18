using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	
	//reference for player health
	//reference for enemy health
	public float speed = 3f;
	public Transform player;
	float lasPOs;
	Rigidbody2D rb;
	int health =100;
	Vector2 tryMove;
	bool enterTrigger = false;
	float distance;
	EnemyAttack enemyAttack;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		lasPOs= transform.position.x;
		enemyAttack = GetComponentInChildren<EnemyAttack>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector2.Distance(transform.position, player.position);
		
		// if player is alive 
		// check distance if faraway 
		// Debug.Log ("las pos " + lasPOs +  "   trans x: " + transform.position.x);
		if (enterTrigger) {
			if (distance > 1f) {
				if (lasPOs < transform.position.x) {
					transform.localEulerAngles = new Vector2 (transform.rotation.y, 180);
				}
				if (lasPOs > transform.position.x) {
					transform.localEulerAngles = new Vector2 (transform.rotation.y, 0);
				}	
			}
		}
		lasPOs= transform.position.x;
	}

	void FixedUpdate () {
		if (enterTrigger){
			rb.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			enterTrigger = true;
		}
	}
	void Attack () {
		enemyAttack.AttackPlayer ();
	}


}
