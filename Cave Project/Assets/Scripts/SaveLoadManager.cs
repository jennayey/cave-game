using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveLoadManager {
	
	public static void SavePlayer (LevelManager levelManager) {
		BinaryFormatter saver = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/gamesave.sv", FileMode.Create);

		GameSave save = new GameSave (levelManager);
		saver.Serialize(stream, save);
		stream.Close();
	}
	
	public static int[] LoadPlayer () {
		
		if (File.Exists(Application.persistentDataPath + "/gamesave.sv")) {
			
			BinaryFormatter saver = new BinaryFormatter();
			FileStream stream = new FileStream(Application.persistentDataPath + "/gamesave.sv", FileMode.Open);
			GameSave save = saver.Deserialize(stream) as GameSave;
			stream.Close();
			
			return save.stats;
		
		}
		else {
			
			
			Debug.LogError ("File does not exist");
			return new int[7];
		}
	}

	


}

[Serializable]
public class GameSave {
	public int[] stats;
	
	public GameSave ( LevelManager levelManager) {
		stats = new int[7]; 
	
		stats [0] = LevelManager.instance.currentLevel;
		stats [1] = LevelManager.instance.rKey;
		stats [2] = LevelManager.instance.sKey;
		stats [3] = LevelManager.instance.foodCount;
		stats [4] = LevelManager.instance.batteryCount;
		stats [5]= LevelManager.instance.playerHealth;
		stats[6] = (int) LevelManager.instance.batteryLife;
		
		
	}
}