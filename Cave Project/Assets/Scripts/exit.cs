using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 


public class exit : MonoBehaviour {
public GameObject loadingScreen, openingScreen;
Transform pMovement;
PlayerMovement playerMovement;
public string levelname;
	// Use this for initialization
	void Awake () {
		
		
	}
	void Start () {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
		StartCoroutine(waitTwoSeconds());
	

	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			
			LevelManager.instance.currentLevel++;
			LevelManager.instance.Save();
			// playerMovement.newLevelStart();
			LoadLevel(levelname);
			// SceneManager.LoadScene(levelname);	
		}
	}

	public void LoadLevel (string levelName) {
		
		
		StartCoroutine(LoadAsychronously(levelName));
			
		
	}

	IEnumerator LoadAsychronously (string lvlName) {
		yield return new WaitForSeconds(.25f);
		loadingScreen.SetActive(true);
		yield return new WaitForSeconds(3);
		AsyncOperation operation = SceneManager.LoadSceneAsync(lvlName);
		
		while (!operation.isDone) {
			
			yield return null;
		}
		
		
	}

	IEnumerator waitTwoSeconds () {
		openingScreen.SetActive(true);
		yield return new WaitForSeconds(1);
		openingScreen.SetActive(false);
	}

}
