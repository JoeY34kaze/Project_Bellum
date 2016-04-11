using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Camera_manager_Main_Menu : MonoBehaviour {
	public float speed=1.0f;
	// Use this for initialization
	void Start () {
		//GameObject.Find ("Network_manager").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);

		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				// the object identified by hit.transform was clicked
			//	Debug.Log ("raycast hit something");
			//	Debug.Log (hit.transform.name);
				if (hit.transform.name.Equals ("Cube_play")) {
					//		Debug.Log ("PLAY");
					SceneManager.LoadScene ("Test_scene");
					
				} else if (hit.transform.name.Equals ("Cube_exit")) {
					//		Debug.Log ("QUIT");
					Application.Quit ();
				} else if (hit.transform.name.Equals ("Sphere_multiplayer")) {
					//nrdit karkol je pac treba za multiplayer
					//od network managerja treba pokazat HUD tle
					//GameObject.Find ("Network_manager").SetActive(true);
					SceneManager.LoadScene("Lobby_scene");

				}
			} else {
				Debug.Log("-\n");
			}
		}

	}
}
