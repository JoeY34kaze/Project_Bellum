using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class player_controller : NetworkBehaviour {
	public float speed = 1;

	Rigidbody rb=null;
	Vector3 movement=Vector3.zero;

	private float x,y,z=0;

	override public void OnStartLocalPlayer(){
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (isLocalPlayer) {
			if (!rb) {
				return;
			}

			x = Input.GetAxis ("Horizontal") * 0.1f;
			z = Input.GetAxis ("Vertical") * 0.1f;

			movement = new Vector3 (x, 0.0f, z);//po y se nebomo rabil premikat po vsej verjetnosti. lest we grow wings

			rb.AddForce (movement * speed);


		}
	}
}
