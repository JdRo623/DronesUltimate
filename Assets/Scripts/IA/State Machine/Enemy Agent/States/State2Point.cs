using UnityEngine;
using System.Collections;

public class State2Point : State{
	public Transform[] goals;
	public Transform enemy;
	public Transform myTransform;
	public float speed;
	private Vector3 direcction;
	public int selectedGoal;
	private Transform goal;
	private System.Random randomGenerator;

	public override void OnEntryAction(){
		randomGenerator = new System.Random();
        Debug.Log(goals.Length);
		selectedGoal = (int)(randomGenerator.NextDouble()*goals.Length);
		this.goal = goals[selectedGoal];
	}
	
	public override void OnUpdateAction(){
			direcction = (goal.position - myTransform.position);
			direcction.Normalize();
			direcction *= speed;
			direcction *= Time.deltaTime;
			myTransform.position+= direcction;
		    transformRotation();
	}
	
	public override void OnExitAction(){
		selectedGoal=0;
		goals=null;
	}
	public bool onLimits(){
		return Vector3.Distance(myTransform.position,goal.position) <= 5;
	}
	public bool enemyClose(){
		return Vector3.Distance (myTransform.position, enemy.position)< 20;
	}
	public void transformRotation(){
		float orientation = Mathf.Atan2(direcction.x,direcction.z);
		orientation *= Mathf.Rad2Deg;
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = new Vector3(0,orientation,0);
		myTransform.rotation = newRotation;
	}
}
