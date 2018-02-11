using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(WaitLang());
		
	}
	IEnumerator WaitLang () {
		yield return new WaitForSeconds(14);
		SceneManager.LoadScene("MainMenu");
	}
}
