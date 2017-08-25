using UnityEngine;
using System.Collections;

public class Vista : MonoBehaviour {

	public GameObject jugador;
	// Use this for initialization
	public int velocidadRotacion;
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {

		float rotacionx=this.transform.rotation.eulerAngles.x;
		bool rangoMovSup = (rotacionx >= 277 && rotacionx <= 360);
		bool rangoMovInf = (rotacionx >= 0 && rotacionx <= 60);
		bool arriba = rotacionx<=277 && rotacionx>270;
		bool abajo = rotacionx>=60 && rotacionx<70;

		if(rangoMovSup && !rangoMovInf){
			arriba=true;
			abajo=false;
		}else if(!rangoMovSup && rangoMovSup){
			abajo=true;
			arriba=false;
		}

		if ( rangoMovSup || rangoMovInf ) {
			this.transform.Rotate ( new Vector3(Input.GetAxis ("RigthJoystickY")*velocidadRotacion, 0, 0));
		}else if(arriba && Input.GetAxis ("RigthJoystickY")>0){
			this.transform.Rotate ( new Vector3(Input.GetAxis ("RigthJoystickY")*velocidadRotacion, 0, 0));	
		}else if(abajo && Input.GetAxis ("RigthJoystickY")<0){
			this.transform.Rotate ( new Vector3(Input.GetAxis ("RigthJoystickY")*velocidadRotacion, 0, 0));
		}

}
}
