using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour {

	// Use this for initialization
	Collider2D mCollider;
	bool enterTrigger;
	void Start () {
		mCollider = GetComponent<Collider2D>();
		if (mCollider!=null)
			Debug.Log ("CHILD COLLIDER FOUND");
		else
			Debug.Log ("CHILD COLLIDER NOT FOUND");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnterTrigger2D (Collider2D other) {
		Debug.Log ("CHILD COLLIDER collided");
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Collided with player");
			
		}
		
	}

}
