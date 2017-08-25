using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;


public class Pause_Mobile : MonoBehaviour {

    private bool options_on = false;
    private bool menu = false;
    private bool graphics = false;
    private bool _audio = false;
    public GUISkin customSkin;
    public GameObject weapons;// weapon manager
    public GameObject gui;
    public GUITexture pause_texture;// "pause" texture







    void Update()
    {
        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (pause_texture.HitTest(touch.position) & touch.phase == TouchPhase.Began & touch.phase != TouchPhase.Stationary)// if pause
            {

                if (!menu)// if menu = false
                 {
                    menu = true;// menu = true
                    menu_on();
                    return;
                }
                else
                {
                        menu = false;// menu = false
                        Time.timeScale = 1;// time is normal
                        menu_off();
                        graphics = false; //close graphics menu
                        options_on = false;//close options menu
						_audio=false;
                        return;
                }
            }

        }
    }

    void OnGUI()
	{
		GUI.skin = customSkin;
		if (menu) {// if menu = true
			Time.timeScale = 0;// time stopped

			if (!options_on) {// if options = false
				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 150, 280, 80), "Continue")) {// if press "continue"
					menu = false; // close menu
					Time.timeScale = 1;// normal time
					menu_off ();
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 85, 280, 80), "Options")) {// if press "options"
					options_on = true;// darw options
				}

				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 20, 280, 80), "Menu")) {// if press "menu"

					menu = false; // close menu
					Time.timeScale = 1;// normal time

					SceneManager.LoadScene (0, LoadSceneMode.Single);
					menu_off ();
					graphics = false; //close graphics menu
					options_on = false;//close options menu 
					_audio = false;
				}
			}

			if (options_on) {// if open options

				if (!graphics & !_audio) {// if graphics = false


					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 150, 280, 80), "Graphics")) {//if press "Graphics"
						graphics = true;
					}
					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 85, 280, 80), "Audio")) {//if press "Audio"
						_audio = true;
					}
					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 20, 280, 80), "Back")) {//if press "Back"
						options_on = false;// close options
					}
				}



			}
			if (graphics) {// if open graphics


				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 165, 280, 80), "High")) {//if press "High"
					QualitySettings.SetQualityLevel (5);// set graphic - Fantastic
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 110, 280, 80), "Normal")) {//if press "Normal"
					QualitySettings.SetQualityLevel (3);// set graphic - Good
				}
				if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 55, 280, 80), "Low")) {//if press "Low"
					QualitySettings.SetQualityLevel (1);// set graphic - Fast

					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 0, 280, 80), "Back")) {//if press "Back"
						graphics = false;// close graphic menu
					}

				}
				if (_audio) {// if graphics = false


					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 150, 280, 80), "On")) {//if press "Graphics"
						PlayerPrefs.SetInt ("audio", 1);
					}
					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 85, 280, 80), "Off")) {//if press "Audio"
						PlayerPrefs.SetInt ("audio", 0);
					}
					if (GUI.Button (new Rect (Screen.width / 2 - 140, Screen.height / 2 - 20, 280, 80), "Back")) {//if press "Back"
						_audio = false;// close options
					}
				}
			}
		}
	}
    

    void menu_on()// if open menu
    {     
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>().enabled = true;      
        weapons.SetActive(false);// deactivate weapons
        gui.SetActive(false); // deactivate textures

    }

    void menu_off()// if menu close
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>().enabled = false;    //
        weapons.SetActive(true);// activate weapons
        gui.SetActive(true);// activate textures
    }
}