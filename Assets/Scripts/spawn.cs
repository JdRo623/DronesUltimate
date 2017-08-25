using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour {
	public GameObject jugador;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerLife.muerte){
			Invoke("darVida",5);
			PlayerLife.muerte=false;
		}
	}
	void darVida(){
		Instantiate(jugador,transform.position, transform.rotation);
	}
}
