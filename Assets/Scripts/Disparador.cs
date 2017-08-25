using UnityEngine;
using System.Collections;

public class Disparador : MonoBehaviour {


	// Use this for initialization
	void start(){

	   
	}
	
	// Update is called once per frame
	void Update () {
		//Este objeto tiene la lista de acciones asociada con cada boton
	//	esquemaControles listaB = new esquemaControles ();
		//Estos son los objetos de los botones con su respectiva accion
	/*	Command  boton_a = new botonA (this.gameObject, listaB.boton_a);
		Command  boton_x = new botonX (this.gameObject, listaB.boton_a);
		Command  boton_y = new botonY (this.gameObject, listaB.boton_a);
		Command  boton_b = new botonB (this.gameObject, listaB.boton_a);*/
		//Aqui se verifica cada frame si se oprimio un boton. De ser asi el boton a ejecuta su accion
		if(Input.GetButton("A")){
			//boton_a.execute();
		}else if(Input.GetButton("X")){
			//boton_x.execute();
		}else if(Input.GetButton("Y")){
			//boton_y.execute();
		}else if(Input.GetButton("B")){
			//boton_b.execute();
		}
	}
}
