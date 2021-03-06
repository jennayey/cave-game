﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	public AudioClip attackClip;
	GameObject weapon;
	public int damage = 1;

	void Start () {
		weapon = GameObject.FindGameObjectWithTag("playerWeapon");
		if (weapon!=null){
			Debug.Log ("Weapon exists");
		}

		weapon.SetActive(false);
	}	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log ("Attacking enemy");
				weapon.SetActive(true);
				SoundManager.instance.PlaySingle(attackClip);
			}

			else 
				weapon.SetActive(false);

	}
	
	
}
