using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization

    
    Scene activeScene;
	void Awake() {
        activeScene = SceneManager.GetActiveScene();
        DontDestroyOnLoad(transform.gameObject);
        Debug.Log ("Activ scene " + activeScene.name);
    }
    

    void ResetDestroyOnLoad () {
        SceneManager.MoveGameObjectToScene(gameObject, activeScene );
    }

    
}
