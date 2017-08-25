using UnityEngine;
using System.Collections;

public class SeekAndFlee : MonoBehaviour, IArtificialIntel {
	public bool seek1;
	public Vector3 direcction;
	public float speed;
	private Transform myTransform;
	public Transform initialTransform;
	//Objetivos
	public Transform goalA;
	public Transform goalB;
	public Transform goalC;
	public Transform goalD;
	public Transform enemy;
	//Vector que guarda objetivos
	public Transform[] goals;
	private System.Random randomGenerator;
	//Variables booleanas
	public bool seeking;
	public bool toCenter;
	public bool toPoint;
	public bool inPatrol;
	public bool idle;
	//
	int selectGoal;
	private Transform target;
	// Use this for initialization
	void Start () {
		//Inicializacion variables booleanas
		inPatrol=false;
		toCenter=false;
		toPoint=false;
		seeking=false;
		idle=true;
		//
		myTransform = transform;
		randomGenerator = new System.Random();
		goals = new Transform[]{goalA,goalB,goalC,goalD};
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log((int)(randomGenerator.NextDouble()*4));

		if(idle){
			selectGoal = (int)(randomGenerator.NextDouble()*4);
			idle=false;
			toPoint=true;
		}else if(toPoint){
			updateGo2Point(selectGoal);
			if(onGoal(goals[selectGoal])){
				toPoint=false;
				toCenter=true;
			}
		}else if(toCenter){
			seek(initialTransform);
			if(onGoal(initialTransform)){
				toPoint=true;
				toCenter=false;
				selectGoal = (int)(randomGenerator.NextDouble()*4);
			}
		}
		if(playerSpotted(enemy) || seeking){
			inPatrol=false;
			toCenter=false;
			toPoint=false;
			seeking=true;
			idle=false;
			seek(enemy);
			if(onGoal(enemy)){
				seeking=false;
				toCenter=true;
			}
		}
		if(playerLost(enemy)){
			seeking=false;
			toCenter=true;
		}
		//patrol();
		transformRotation();

	}
	private void updateGo2Point(int goal){
		seek(goals[goal]);
	}
	public void flee(Transform target){
		transformDirection(-1,target);
	} 
	public void seek(Transform target){
		transformDirection(1,target);
	}
	public void transformDirection(int direct, Transform target){
		direcction = (target.position - myTransform.position)*direct;
		direcction.Normalize();
		direcction *= speed;
		direcction *= Time.deltaTime;
		myTransform.position+= direcction;
	}
	public void transformRotation(){
		float orientation = Mathf.Atan2(direcction.x,direcction.z);
		orientation *= Mathf.Rad2Deg;
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = new Vector3(0,orientation,0);
		myTransform.rotation = newRotation;
	}
	public void patrol(){
		/*if((getDistanceBet(initialTransform)<2 || getDistanceBet(initialTransform)>-2)){
			moveOnRandom();
		}else if(onGoal()){
			seek(initialTransform);
			inPatrol=false;
		}*/
		  
		
	}
	private float getDistanceBet(Transform obj){
		return Vector3.Distance(myTransform.position, obj.position);

	}
	public bool limitsOnX(Transform target){
		return (target.position.x - myTransform.position.x < 2) && (target.position.x - myTransform.position.x > -2) ;
	}

	public bool limitsOnY(Transform target){
		return (target.position.z - myTransform.position.z < 2) && (target.position.z - myTransform.position.z > -2);
	}

	private bool onGoal(Transform target){
		return ( getDistanceBet(target)<=5 );
	}
	private bool playerSpotted(Transform player){
		return (getDistanceBet(player)<=15);
	}
	private bool playerLost(Transform player){
		return (getDistanceBet(player)>30);
	}
	private void moveOnRandom(){
		double path= randomGenerator.NextDouble()*4;
		inPatrol=true;
		if(path<1){
			seek(goalA);

		}else if(path<2){
			seek(goalB);
		
		}else if(path<3){
			seek(goalC);
			
		}else if(path<4){
			seek(goalD);
			
		}
	}
}
