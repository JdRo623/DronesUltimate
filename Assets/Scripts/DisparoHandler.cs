using UnityEngine;
using System.Collections;

public class DisparoHandler : MonoBehaviour {

	public float daño;
	private float lifeTime=5;
	private float aLifeTime;
	// Use this for initialization
	void Start () {
		aLifeTime = lifeTime;
	}
	void Update(){
		aLifeTime = lifeTime - Time.time*Time.deltaTime;
		checkLifeTime();
	}

	public float dañoCausado(){
		return daño;
	}

	void OnTriggerEnter(Collider otro){
		if(otro.tag!="Bala"){
			Destroy (this.gameObject);
		}
			
	}
	void checkLifeTime(){
		if(aLifeTime==0){
			Destroy (this.gameObject);
		}
	}
}
