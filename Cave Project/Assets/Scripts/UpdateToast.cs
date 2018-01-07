using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateToast : MonoBehaviour {

	// Use this for initialization
	public Text toastText;
	public string textUp;
	private static UpdateToast _instance;
	public void UpdatedToast () {
		StartCoroutine(upToast());
	}
	
	void Start (){
		toastText = GameObject.Find("Toast").GetComponent<Text>();
		if (toastText!=null)
			Debug.Log ("UPDATE TOAST WORK");
		else
			Debug.Log ("UPDATE NOT WORKING");
		
	}
	public IEnumerator upToast() {

        toastText.text = textUp; 
        yield return new WaitForSeconds(5);
        toastText.text= " ";
  

	}



}
