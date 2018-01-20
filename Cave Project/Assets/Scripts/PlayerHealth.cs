 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	public Image damageImage;
	public Slider healthSlider;
	public Color damageColor  = new Color (1f, 0 , 0 , .1f);
	public Color deathColor = new Color (0 , 0, 0 , .5f);
	public int health = 100;
	void Start () {
		damageImage.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = health;
		damageImage.color = Color.Lerp (damageImage.color, Color.clear, 5f*Time.deltaTime);
	}	

	public void takeDamage (int damage) {
		if (health>=1) {
			damageImage.color = damageColor;
			health-=damage;
		}

		else if (health==0) {
			damageImage.color = deathColor;
		}
		
			
		
	}

	void Die () {
		Debug.Log("Dead");
	}
}
