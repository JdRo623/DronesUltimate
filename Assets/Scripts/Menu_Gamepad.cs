using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Gamepad : MonoBehaviour {

	public  Camera cameramenu;//camera in menu
	public Transform door;//  left door in menu
	public Transform door2;// right door in menu
	public GameObject Menu1;//left words in menu
	public GameObject Menu2;// right words in menu
	public GameObject Opt;// options
	public GameObject FPC;// first person controller
	public GameObject arena;// arena control script
	bool option = false;
	private float camtime;
	public bool listener = true;
	private bool on;
	bool a = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (option == false) {
			if (Input.GetButtonDown ("Play")) {// if play(click)
				door.GetComponent<Animation> ().Play ("DorOpen1"); // close doors
				door2.GetComponent<Animation> ().Play ("DorOpen2");//
				on = true;
			}

			if (Input.GetButtonDown ("Options")) {// if options
				Menu1.SetActive (false);// deactivation menu
				Menu2.SetActive (false);// 
				Opt.SetActive (true);// activation options
				option = true;
			}
		}
		if (option == true) {
			// set graphics
			if (Input.GetButtonDown ("Hight")) {
				QualitySettings.SetQualityLevel (5);// set graphic - Fantastic
			}
			if (Input.GetButtonDown ("Normal")) {
				QualitySettings.SetQualityLevel (3);// set graphic - Fantastic
			}
			if (Input.GetButtonDown ("Low")) {
				QualitySettings.SetQualityLevel (1);// set graphic - Fantastic
			}
			if (Input.GetButtonDown ("Back")) {// if back
				Menu1.SetActive (true);// activation menu
				Menu2.SetActive (true);//
				Opt.SetActive (false);// deactivation options
				option=false;
			}
			if (Input.GetButtonDown ("Reset")) {// if reset game
				PlayerPrefs.SetInt ("Score", 0);// score = 0
			}
			if (Input.GetButtonDown ("Exit")) {// if exit
				Application.Quit ();// exit game
			}
			if (Input.GetButtonDown ("Audio_On")) { 
				PlayerPrefs.SetInt ("audio", 1);
			}
			if (Input.GetButtonDown ("Audio_Off")) {
				PlayerPrefs.SetInt ("audio", 0);
			}
		}


		if (on) {// if play
			Cursor.visible = false;// cursor = false
			cameramenu.GetComponent<Animation> ().CrossFade ("CamInto");// play animation
			camtime += Time.deltaTime;
		}
		if (camtime >= cameramenu.GetComponent<Animation> () ["CamInto"].length) {
			FPC.SetActive (true);// activation player
			cameramenu.enabled=false;// deactivation menu camera
			a = true;
			on = false;
			camtime = 0;
		}
		if (a == true) {
			door.GetComponent<Animation> ().Play ("DorClose1"); // close doors
			door2.GetComponent<Animation> ().Play ("DorClose2");//
			cameramenu.GetComponent<Animation> ().Play ("CamBack");// play animation
			cameramenu.GetComponent<Animation> ().CrossFade ("CameraMenuAnim");// play animation
			a = false;
			arena.SetActive (true);// activation script arena control
		}
	}
}
