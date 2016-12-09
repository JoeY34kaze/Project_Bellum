using UnityEngine;
//using UnityEngine.Networking;
	public class SmoothFollow : MonoBehaviour
	{

		// The target we are following
		[SerializeField]
		public Transform target;
		// The distance in the x-z plane to the target
		[SerializeField]
		public float distance = 2.0f;
		// the height we want the camera to be above the target
		[SerializeField]
		public float height = 0.8f;
		public float extra_height=1.5f;


	private float change_in_rotation_horizontal = 0.0f;
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
			change_in_rotation_horizontal=Input.GetAxis("Mouse X");
			
			float wantedHeight = target.position.y + height;

			float currentRotationAngle = transform.eulerAngles.y;

			
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position- target.forward * distance;
			
			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,wantedHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
			


			//extra finese
		transform.position = new Vector3 (transform.position.x, transform.position.y + extra_height, transform.position.z);

			//dal bi se nrdit da gledas cez ramo recimo
		}
	}
