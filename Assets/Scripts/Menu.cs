using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	private RaycastHit hit;
	public  Camera cameramenu;//camera in menu
    public Transform door;//  left door in menu
    public Transform door2;// right door in menu
    public GameObject Menu1;//left words in menu
    public GameObject Menu2;// right words in menu
    public GameObject Opt;// options
    public GameObject FPC;// first person controller
    public GameObject arena;// arena control script
    private float camtime;
	public bool listener = true;
    private bool on;
    bool a = false;


    void Start()
    {
		cameramenu.GetComponent<Animation>().CrossFade("CameraMenuAnim");// play animation in menu
        Cursor.visible = true; // cyrsor = true


    }

    void Update()
    {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = cameramenu.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit,100)) {

				if (hit.collider.CompareTag ("Play")) {// if play(click)
					door.GetComponent<Animation> ().Play ("DorOpen1"); // close doors
					door2.GetComponent<Animation> ().Play ("DorOpen2");//
					on = true;
				}

				if (hit.collider.CompareTag ("Options")) {// if options
					Menu1.SetActive (false);// deactivation menu
					Menu2.SetActive (false);// 
					Opt.SetActive (true);// activation options
				}
				// set graphics
				if (hit.collider.CompareTag ("Hight")) {
					QualitySettings.SetQualityLevel (5);// set graphic - Fantastic
				}
				if (hit.collider.CompareTag ("Normal")) {
					QualitySettings.SetQualityLevel (3);// set graphic - Fantastic
				}
				if (hit.collider.CompareTag ("Low")) {
					QualitySettings.SetQualityLevel (1);// set graphic - Fantastic
				}
				if (hit.collider.CompareTag ("Back")) {// if back
					Menu1.SetActive (true);// activation menu
					Menu2.SetActive (true);//
					Opt.SetActive (false);// deactivation options
				}
				if (hit.collider.CompareTag ("Reset")) {// if reset game
					PlayerPrefs.SetInt ("Score", 0);// score = 0
				}
				if (hit.collider.CompareTag ("Exit")) {// if exit
					Application.Quit ();// exit game
				}
				if (hit.collider.CompareTag ("Audio_On")) { 
					PlayerPrefs.SetInt ("audio", 1);
				}
				if (hit.collider.CompareTag ("Audio_Off")) {
					PlayerPrefs.SetInt ("audio", 0);
				}
			}
		}

        if (on)// if play
        {
            Cursor.visible = false;// cursor = false
			cameramenu.GetComponent<Animation>().CrossFade("CamInto");// play animation
            camtime += Time.deltaTime;
        }
		if (camtime >= cameramenu.GetComponent<Animation>()["CamInto"].length)
        {
			FPC.SetActive (true);// activation player
			cameramenu.enabled=false; // deactivation menu camera
            a = true;
            on = false;
            camtime = 0;
        }
        if (a == true)
        {
            door.GetComponent<Animation>().Play("DorClose1"); // close doors
            door2.GetComponent<Animation>().Play("DorClose2");//
			cameramenu.GetComponent<Animation>().Play("CamBack");// play animation
			cameramenu.GetComponent<Animation>().CrossFade("CameraMenuAnim");// play animation
            a = false;
			arena.SetActive (true);// activation script arena control
        }


    }
}


