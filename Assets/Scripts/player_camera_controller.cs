using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_camera_controller : NetworkBehaviour {
	override public void OnStartLocalPlayer(){//ce zamenam na onnetworkinstatiate follow ne dela.
//#if UNITY_EDITOR
		Camera.main.transform.SetParent(transform);//nastav kamero kot child object
		Camera.main.GetComponent<SmoothFollow> ().target = transform;

//#endif
	}

}
