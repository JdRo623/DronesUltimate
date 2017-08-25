using UnityEngine;
using System.Collections;

public class Movimiento_PreAlpha : MonoBehaviour {
	public float velocidadDespzamiento;
	public float velocidadGiro;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Mouse X");
		if (Input.GetKey(KeyCode.UpArrow)){			
			this.transform.Translate(Vector3.forward * velocidadDespzamiento);	
		}	
		
		if (Input.GetKey(KeyCode.S))	
		{
			this.transform.Translate(Vector3.back * velocidadDespzamiento);	
		}

		if (Input.GetKey(KeyCode.A))
			
		{
			this.transform.Translate(Vector3.left * velocidadDespzamiento);
			
		}

		if (Input.GetKey(KeyCode.D))
			
		{
			this.transform.Translate(Vector3.right * velocidadDespzamiento);
			
		}

		if (Input.GetKey(KeyCode.W)){	
			this.transform.Translate(Vector3.forward * velocidadDespzamiento);	
		}
		this.transform.Rotate(Vector3.up * horizontal*velocidadGiro);
	}

}
