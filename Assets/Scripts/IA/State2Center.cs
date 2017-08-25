using UnityEngine;
using System.Collections;

public class State2Center : State {
	public Transform initialTransform;
	public Transform myTransform;
	public Transform enemy;
	public float speed;
	private Vector3 direcction;

	public override void OnEntryAction(){

	}
	
	public override void OnUpdateAction(){
		direcction = (initialTransform.position - myTransform.position);
		direcction.Normalize();
		direcction *= speed;
		direcction *= Time.deltaTime;
		myTransform.position+= direcction;
		transformRotation();
	}
	
	public override void OnExitAction(){

	}
	public bool onLimits(){
		return (Vector3.Distance(myTransform.position,initialTransform.position))<=1;
	}

	public bool enemyClose(){
		return Vector3.Distance (myTransform.position, enemy.position) < 20;
	}
	public void transformRotation(){
		float orientation = Mathf.Atan2(direcction.x,direcction.z);
		orientation *= Mathf.Rad2Deg;
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = new Vector3(0,orientation,0);
		myTransform.rotation = newRotation;
	}
}
