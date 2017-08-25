using UnityEngine;
using System.Collections;

public class Disparo : MonoBehaviour {
	// Use this for initialization
	public GameObject bala;
	public int velocidadDisparo;
	private int contadorDisparos=0;
	public float congelamiento;
	private float espera=0;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && Time.time > espera || Input.GetAxis("RigthTrigger")>0){//Se esta presionando el boton izquierdo del mouse
			espera= 50 + Time.time ;
			disparo();
		}

	}
	

	void disparo(){
		contadorDisparos++;
		GameObject clon;
		clon=Instantiate(bala, transform.position, transform.rotation) as GameObject;
		clon.transform.Rotate(90,0,0);
		clon.GetComponent<Rigidbody>().velocity=transform.TransformDirection(Vector3.forward*velocidadDisparo);

	}
}
