using UnityEngine;
using System.Collections;

public class TiempoAbsoluto : MonoBehaviour {
	public float tiempoInicial;
	public static float tiempoRestante;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tiempoRestante = tiempoInicial - Time.time;
	}
}
