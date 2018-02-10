using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource musicBG; 
	public AudioSource musicSFX;
	public static SoundManager instance = null;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else if (instance!=this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}

	public void PlaySingle (AudioClip clip) {
		musicSFX.clip = clip; 
		musicSFX.Play();
	}
}
