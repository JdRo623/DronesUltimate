using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour {
	
	private float tiempoRestante;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		tiempoRestante = TiempoAbsoluto.tiempoRestante;
		if (tiempoRestante>0) {
			text.text= (int)tiempoRestante+"";
				} else {
			text.text="0:00";		
		}

	}
}
