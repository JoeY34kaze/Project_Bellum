using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class main_camera : NetworkBehaviour {
	override public void OnStartLocalPlayer(){
#if UNITY_EDITOR
		Camera.main.GetComponent<SmoothFollow> ().target = transform;
#endif
	}

}
