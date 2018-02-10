 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	// Use this for initialization
	public AudioClip hurtClip;
	public Image damageImage;
	public Slider healthSlider;
	public Color damageColor  = new Color (1f, 0 , 0 , .5f);
	public Color deathColor = new Color (0 , 0, 0 , .5f);
	public int health = 100;
	void Start () {
		//damageImage.color = Color.clear;
		
	
	}
	// Update is called once per frame
	void Update () {
		healthSlider.value = LevelManager.instance.playerHealth;
		
	}	

	public void takeDamage (int damage) {
		if (LevelManager.instance.playerHealth>=1) {
			damageImage.color = damageColor;
			LevelManager.instance.playerHealth-=damage;
			SoundManager.instance.PlaySingle(hurtClip);
		}

		else if (LevelManager.instance.playerHealth==0) {
			damageImage.color = deathColor;
		}
		damageImage.color = Color.Lerp (damageImage.color, Color.clear, 5f*Time.deltaTime);
			
		
	}

	void Die () {
		Debug.Log("Dead");
	}
}
