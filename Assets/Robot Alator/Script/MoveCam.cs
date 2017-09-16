using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour { 
		public Transform target;  
		public float distance = 6.0f;  
		public float xSpeed = 80.0f;  
		public float ySpeed = 50.0f;  
		public float targetHeight = 3.5f;  
		public float yMinLimit = -10; 
		public float yMaxLimit = 50; 
		public float maxDistance = 10.0f; 
		public float minDistance = 6.0f; 
		public float zoomRote = 60.0f; 

		private float x = 0.0f;  
		private float y = 0.0f;  

		[AddComponentMenu("Scripts/Mouse Orbit")] 

		public void Start() 
	{   
			 
			Vector3 angles = transform.eulerAngles; 
			x = angles.y; 
			y = angles.x; 
		} 

		public void LateUpdate() {   
			if (target) { 
				 
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f; 
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;  
				distance -= (Input.GetAxis ("Mouse ScrollWheel") * Time.deltaTime) * zoomRote * Mathf.Abs(distance); 
				distance = Mathf.Clamp (distance, minDistance, maxDistance); 

				y = ClampAngle(y,yMinLimit, yMaxLimit);   
			    MovePlayer.x = x; 
				Quaternion rotation = Quaternion.Euler(y, x, 0); 
				transform.rotation = rotation; 

				 
				Vector3 position = rotation * new Vector3(0.0f, targetHeight+0.5f, -distance) + target.position; 
				transform.position = position; 

				   
				RaycastHit hit; 
				Vector3 trueTargetPosition = target.transform.position - new Vector3(0, -targetHeight,0); 
				if(Physics.Linecast (trueTargetPosition, transform.position, out hit)) 
				{ 
					float tempDistance = Vector3.Distance (trueTargetPosition, hit.point) - 0.28f; 
					position = target.position - (rotation * Vector3.forward * tempDistance + new Vector3(0, -targetHeight, 0)); 
					transform.position = position; 
				} 
			} 

		} 
		 
		public static float ClampAngle (float angle, float min, float max) { 
			if(angle < -360) 
				angle += 360; 
			if(angle > 360) 
				angle -= 360; 
			return Mathf.Clamp (angle, min, max); 
		} 
	} 

	
