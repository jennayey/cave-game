using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	public static bool newSave = false;

	public static void createNew () {
		newSave = true;
	}

	public static void loadSave () { 
		newSave = false;
	}
}
