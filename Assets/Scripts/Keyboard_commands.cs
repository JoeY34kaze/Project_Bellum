using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Keyboard_commands : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
		//draw prompt stuff
			//displayDialogue returns true if "ok" button is pressed
			if(EditorUtility.DisplayDialog("Are you sure you want to return back to the Main menu?", "Yes", "Cancel")){
				SceneManager.LoadScene("Main_menu");
			}
		}
	}
}
