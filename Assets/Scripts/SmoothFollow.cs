﻿using UnityEngine;
//using UnityEngine.Networking;
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		public Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		public float distance = 10.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		public float height = 5.0f;

		[SerializeField]
		public float rotationDamping;
		[SerializeField]
		public float angularSpeed;
		[SerializeField]
		public float heightDamping;

		// Use this for initialization
//	void OnNetworkInstantiate(NetworkMessageInfo info){//upam da tole poprav kamero. tezava je ker smoothscript zahteva networkidentity (sej nevem če je to treba ampak pomoje je treba)
//		this.gameObject.SetActive(true);
//	}

		// Update is called once per frame
		void LateUpdate()
		{
			// Early out if we don't have a target
			if (!target)
				return;

			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y+Input.GetAxis("Mouse X");
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);




			float movement = Input.GetAxis ("Mouse X") * angularSpeed * Time.deltaTime;
			//Debug.Log ("mouse movement: "+movement);
			Debug.Log("current rotation angle:\t "+currentRotationAngle+" wanted rotation angle:\t "+wantedRotationAngle+" current rotation:\t "+currentRotation+" object:"+gameObject.name);
			//transform.RotateAround (target.position, Vector3.up,movement);
			//Camera.main.transform.RotateAround(target.position,Vector3.up,wantedRotationAngle);
			//currentOffset = transform.position - target.position;
			transform.eulerAngles.Set(transform.eulerAngles.x,transform.eulerAngles.y+movement,transform.eulerAngles.z);//to bi moral delat, ampak sj do zdej bi mogl ze vse delat. update: tut nedela


			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
		}
	}
