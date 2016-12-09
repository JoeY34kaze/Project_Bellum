using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class charcater_controller : NetworkBehaviour {
	public float speed = 1.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float run=1.5f;
	public float sprint=1.5f;
	private float horizontal = 0;
	private float vertical=0;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;
	private Vector3 lookAt;
	private CharacterController controller;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void Update() {
		if (!isLocalPlayer) {
			return;
		}
		controller = transform.GetComponent<CharacterController>();
		horizontal = Input.GetAxis ("Horizontal");
		vertical=Input.GetAxis ("Vertical");

		// Controling character rotation
		lookAt = new Vector3( 0, Input.GetAxis( "Mouse X" ), 0 );
		controller.transform.Rotate(lookAt);





		if (controller.isGrounded) {
			if (Input.GetKeyDown (KeyCode.LeftControl)) {
				bool temp=anim.GetBool ("crouched");
				anim.SetBool ("crouched", !temp);
			}


			anim.SetFloat ("horizontal",horizontal);
			anim.SetFloat ("movement_speed",vertical);
			if (horizontal + vertical != 0) {
				anim.SetBool ("moving",true);
			} else {
				anim.SetBool ("moving",false);
			}
			moveDirection = new Vector3(horizontal, 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//moveDirection *= speed;

			anim.SetFloat ("movement_speed",Input.GetAxis ("Vertical"));

			if (!Input.GetButton ("Run") && !Input.GetButton ("Modifier1")) {
				anim.SetBool ("Sprinting", false);
				anim.SetBool ("Running", false);
			}

			if (Input.GetButton ("Run")) {
				anim.SetBool ("Running", true);
				moveDirection *= run;
				if (Input.GetButton ("Modifier1")) {
					anim.SetBool ("Sprinting", true);
					moveDirection *= sprint;
				} else {
					anim.SetBool ("Sprinting", false);
				}
			} else {
				anim.SetBool ("Running", false);
			}




			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;




		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
