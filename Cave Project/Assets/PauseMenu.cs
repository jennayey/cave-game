using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject pauseMenuUI, instructions;
	public static bool gameIsPaused = false;
	GameObject pause;
	// Update is called once per frame
	void Start () {
		
	}
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused) {
				resumeGame();
			}
			else
				pauseGame ();
			
		}

	}

	public void resumeGame () {
		pauseMenuUI.SetActive(false);
		instructions.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;

	 	
	}

	public void pauseGame(){
	
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
	
	public void mainMenu () {	
		pauseMenuUI.SetActive(false);
		resumeGame();
		LevelManager.instance.sKey -=LevelManager.instance.acqSkeys;
		LevelManager.instance.rKey -=LevelManager.instance.acqKeys;
		LevelManager.instance.foodCount -=LevelManager.instance.acqFood;
		LevelManager.instance.batteryCount -=LevelManager.instance.acqBatteries;
		LevelManager.instance.Save();
		SceneManager.LoadScene ("MainMenu");
		
		
		

	}
	
}
