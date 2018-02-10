using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void StartGame() {
		SceneManager.LoadScene("Main");
		NewGame.createNew();
	}
	public void ContinueGame() {
		NewGame.loadSave();
		int[] loadedStats = SaveLoadManager.LoadPlayer();

		int currentLevel = loadedStats [0];

		switch (currentLevel) {
			case 0: 
				SceneManager.LoadScene("Main");
				break;
			case 1: 
				SceneManager.LoadScene("Level1");
				break;
			case 2: 
				SceneManager.LoadScene("Level2");
			
				break;
			case 3: 
				SceneManager.LoadScene("Level3");
				break;
			case 4: 
				SceneManager.LoadScene("Level4");
				break;	
			case 5: 
				SceneManager.LoadScene("Level5");
				break;
		}
	
	
	}	
	public void QuitGame () {
		Application.Quit();
	}
}
