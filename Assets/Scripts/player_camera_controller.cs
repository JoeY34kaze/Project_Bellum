using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_camera_controller : NetworkBehaviour {
	override public void OnStartLocalPlayer(){//ce zamenam na onnetworkinstatiate follow ne dela.
//#if UNITY_EDITOR
		Camera.main.transform.SetParent(transform);//nastav kamero kot child object
		Camera.main.GetComponent<SmoothFollow> ().target = transform;

		//Renderer[] rends = GetComponentsInChildren<Renderer> ();//tole za renderje je blo u tutorialu https://www.youtube.com/watch?v=ZsZiHe8yN9A ampak nevem zakaj
		//foreach (Renderer r in rends) {
		//	r.enabled=false;
		//}
		GetComponent<NetworkAnimator> ().SetParameterAutoSend (0, true);//tole je nastavlen sam na local player, treba je še na remote
//#endif
	}

	public override void PreStartClient ()
	{
		//base.PreStartClient ();
		GetComponent<NetworkAnimator> ().SetParameterAutoSend (0, true);//zdj je še na remote
	}
}
