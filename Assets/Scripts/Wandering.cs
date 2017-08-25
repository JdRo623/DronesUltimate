using UnityEngine;
using System.Collections;

public class Wandering : MonoBehaviour {
	private System.Random randomGenerator;
	public float randomRange= 90;

	public float speed;
	public Vector3 direction;
	private Transform myTransform;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		randomGenerator = new System.Random();
	}
	
	// Update is called once per frame
	void Update () {
		float orientation = BinaryRandom();
		orientation*= randomRange;
		Vector3 newEulerAngles = new Vector3(0,orientation,0);
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = newEulerAngles;
		myTransform.rotation = newRotation;

		myTransform.rotation=newRotation;
	   
	}
	private float BinaryRandom(){
		float random1 = (float) randomGenerator.NextDouble();
		float random2 = (float) randomGenerator.NextDouble();
		return random1 - random2;
	}
}
