using UnityEngine;
using System.Collections;

public class Fisicas : MonoBehaviour
{

	public float gravedad;
	public float fuerzaSalto;
	public float velocidad;
	public float rotacion;

	// Use this for initialization
	void Start ()
	{
		gravedad=gravedad*Time.deltaTime;
		fuerzaSalto=fuerzaSalto*Time.deltaTime;
		velocidad=velocidad*Time.deltaTime;
		rotacion=rotacion*Time.deltaTime;
	}


}

