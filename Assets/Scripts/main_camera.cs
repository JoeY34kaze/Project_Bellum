using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class main_camera : NetworkBehaviour {
	override public void OnStartLocalPlayer(){//ce zamenam na onnetworkinstatiate follow ne dela. tole mislm da nrdi samo hostu, ne izvede se pa na clientih. mogoče rpc nrdit al pa kej?
//#if UNITY_EDITOR
		Camera.main.GetComponent<SmoothFollow> ().target = transform;
//#endif
	}

}
