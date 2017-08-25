 using UnityEngine;
using System.Collections;

public class Menu_Mobile : MonoBehaviour
{
    private RaycastHit hit;
    public Transform door;//  left door in menu
    public Transform door2;// right door in menu
    public GameObject Menu1;//left words in menu
    public GameObject Menu2;// right words in menu
    public GameObject Opt;// options
    public GameObject cam;// camera in menu
    public GameObject fps;// first person controller
    public GameObject arena;// arena control script
    private float camtime;
    private bool on;
    void Start()
    {
        cam.GetComponent<Animation>().CrossFade("CameraMenuAnim");// play animation in menu
    }


    void Update()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("Play"))// if play(click)
                {
                    door.GetComponent<Animation>().Play("DorOpen1"); // close doors
                    door2.GetComponent<Animation>().Play("DorOpen2");//
                    on = true;
                }
            }

            if (hit.collider.CompareTag("Options"))// if options
            {
                Menu1.SetActive(false);// deactivation menu
                Menu2.SetActive(false);// 
                Opt.SetActive(true);// activation options
            }
            // set graphics
            if (hit.collider.CompareTag("Hight"))
            {
				QualitySettings.SetQualityLevel (5);// set graphic - Fantastic
            }
            if (hit.collider.CompareTag("Normal"))
            {
				QualitySettings.SetQualityLevel (3);// set graphic - Good
            }
            if (hit.collider.CompareTag("Low"))
            {
				QualitySettings.SetQualityLevel (1);// set graphic - Fast
            }
            if (hit.collider.CompareTag("Back"))// if back
            {
                Menu1.SetActive(true);// activation menu
                Menu2.SetActive(true);//
                Opt.SetActive(false);// deactivation options
            }
            if (hit.collider.CompareTag("Reset"))// if reset game
            {
                PlayerPrefs.SetInt("Score", 0);// score = 0
            }
            if (hit.collider.CompareTag("Exit"))// if exit
            {
                Application.Quit();// exit game
            }
			if (hit.collider.CompareTag ("Audio_On")) { 
				PlayerPrefs.SetInt ("audio", 1);
			}
			if (hit.collider.CompareTag ("Audio_Off")) {
				PlayerPrefs.SetInt ("audio", 0);
			}
        }

        if (on)// if play
        {
            cam.GetComponent<Animation>().CrossFade("CamInto");// play animation
            camtime += Time.deltaTime;
        }
        if (camtime >= cam.GetComponent<Animation>()["CamInto"].length)
        {
            fps.SetActive(true);// activation player
            cam.SetActive(false);// deactivation menu camera
            on = false;
            camtime = 0;
            arena.SetActive(true);// activation script arena control
            door.GetComponent<Animation>().Play("DorClose1"); // close doors
            door2.GetComponent<Animation>().Play("DorClose2");//
            cam.GetComponent<Animation>().Play("CamBack");// play animation
            cam.GetComponent<Animation>().CrossFade("CameraMenuAnim");// play animation
        }


    }
}


