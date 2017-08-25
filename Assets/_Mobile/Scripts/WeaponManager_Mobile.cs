using UnityEngine;
using System.Collections;

public class WeaponManager_Mobile : MonoBehaviour
{
	public int current_Weapon;// current weapon
	public bool can_change_weapons;

	public GameObject weapon1;//weapon 1 prefab
	public GameObject weapon2;//weapon 2 prefab
	public GameObject weapon3;//weapon 3 prefab
	public GameObject weapon4;//weapon 4 prefab
	public GameObject weapon5;//weapon 5 prefab
	public GameObject weapon6;//weapon 6 prefab
	public GameObject weapon7;//weapon 7 prefab

    public RocketLauncher_Mobile rs;               //
    public Gun_Mobile ws;    //
	public SnaiperRifle_Mobile hd;  //
    public Machine_Mobile bn;     // links to weapons scripts
    public Flamethrower_Mobile to;                 //
	public Submachinegun_Mobile nk;         //
    public Knife_Mobile aka;          //

	private int weapon1_mode;
	private int weapon2_mode;
	private int weapon3_mode;
	private int weapon4_mode;
	private int weapon5_mode;
	private int weapon6_mode;
	private int weapon7_mode;

    public GUITexture weapon_1;  //
    public GUITexture weapon_2;  //
    public GUITexture weapon_3;  // weapon change textures
    public GUITexture weapon_4;  //
    public GUITexture weapon_5;  //
    public GUITexture weapon_6;  //
    public GUITexture weapon_7;  //

	public bool have_Gun = false;
	public bool have_Machine = false;
	public bool have_Rocket_Launcher = false;
	public bool have_Flamethrower = false;
	public bool have_Submachine_Gun = false;
	public bool have_Knife = false;
	public bool have_Sniper_rifle = false;


	public GameObject hptexture;  //
	public GameObject pattexture; //
	public GameObject grentexture;// ammo,health textures
	public GameObject hptext;     //
	public GameObject pattext;    //
	public GameObject grentext;   //


    void Start()
    {
		weapon_1.enabled = false;
		weapon_2.enabled = false;
		weapon_3.enabled = false;
		weapon_4.enabled = false;
		weapon_5.enabled = false;
		weapon_6.enabled = false;
		weapon_7.enabled = false;

		pattexture.SetActive(true);  //
		grentexture.SetActive(true); // 
		hptexture.SetActive(true);   //
		hptext.SetActive(true);      // activate all textures
		pattext.SetActive(true);     //
		grentext.SetActive(true);    //
    }


    void Update()
	{
		if (hd.aim == false & ws.aim == false & bn.aim == false & nk.aim == false) { // if aim off
			can_change_weapons = true;
		} else {
			can_change_weapons = false;
		}
		


		if (current_Weapon > 7) {
			current_Weapon = 1;
			Switch ();
		}
		if (current_Weapon < 1) {
			current_Weapon = 7;
			Switch ();
		}

		int count = Input.touchCount;
		for (int i = 0; i < count; i++) 
		{
			Touch touch = Input.GetTouch (i);

			if (weapon_1.HitTest (touch.position) & can_change_weapons == true) {// if press gun,and aim off(all weapons)
				if (weapon1_mode == 0) {// if gun inactive
					Null_Weapons_mode ();
					weapon1_mode = 1;
					current_Weapon = 1; //curent weapon = 1
					Switch ();
				}
			}

			if (weapon_2.HitTest (touch.position) & can_change_weapons == true) {// if press snaiper rifle,and aim off(all weapons)
				if (weapon2_mode == 0) {// if snaiper rifle inactive
					Null_Weapons_mode ();
					weapon2_mode = 1;
					current_Weapon = 2;//curent weapon = 2
					Switch ();
				}
			}

			if (weapon_3.HitTest (touch.position) & can_change_weapons == true) {// if press rocket launcher,and aim off(all weapons)
				if (weapon3_mode == 0) {// if rocket launcher inactive
					Null_Weapons_mode ();
					weapon3_mode = 1;
					current_Weapon = 3;//curent weapon = 3
					Switch ();
				}
			}
			if (weapon_4.HitTest (touch.position) & can_change_weapons == true) {// if press machinegun,and aim off(all weapons)
				if (weapon4_mode == 0) {// if machine gun inactive
					Null_Weapons_mode ();
					weapon4_mode = 1;
					current_Weapon = 4;//curent weapon = 4
					Switch ();
				}
			}
			if (weapon_5.HitTest (touch.position) & can_change_weapons == true) {// if press firegun,and aim off(all weapons)
				if (weapon5_mode == 0) {// if flamethrower inactive
					Null_Weapons_mode ();
					weapon5_mode = 1;
					current_Weapon = 5;//curent weapon = 5
					Switch ();
				}
			}

			if (weapon_6.HitTest (touch.position) & can_change_weapons == true) {// if press lasergun,and aim off(all weapons)
				if (weapon6_mode == 0) {// if laser inactive
					Null_Weapons_mode ();
					weapon6_mode = 1;
					current_Weapon = 6;//curent weapon = 6
					Switch ();
				}
			}

			if (weapon_7.HitTest (touch.position) & can_change_weapons == true) {// if press knife,and aim off(all weapons)
				if (weapon7_mode == 0) {// if knife inactive
					Null_Weapons_mode ();
					weapon7_mode = 1;
					current_Weapon = 7;//curent weapon = 7
					Switch ();
				}
			}
		}
	}
		
    public void Null()
    {
        weapon1.SetActive(false);//
		weapon2.SetActive(false);//
		weapon3.SetActive(false);//
		weapon4.SetActive(false);// deactivate all weapons 
		weapon5.SetActive(false);//
		weapon6.SetActive(false);//
		weapon7.SetActive(false);//

    }

	public void Null_Weapons_mode(){

		weapon1_mode = 0;//
		weapon2_mode = 0;//
		weapon3_mode = 0;//
		weapon4_mode = 0;// deactivate all weapons mode
		weapon5_mode = 0;//
		weapon5_mode = 0;//
		weapon6_mode = 0;//
	}

    public void Switch()// switch weapons
    {

		if (current_Weapon == 1)// if current weapon = 1
        {
			if (have_Gun == true) {
				Null ();
				weapon1.SetActive (true);//activate 1 weapon
				weapon1.GetComponent<Animation> ().Play ("Gun_On");	
			}
        }

		if (current_Weapon == 2)// if current weapon = 2
        {
			if (have_Sniper_rifle == true) {
				Null ();
				weapon2.SetActive (true);//activate 2 weapon
				weapon2.GetComponent<Animation> ().Play ("SniperRifle_On");
			}
        }

		if (current_Weapon == 3)// if current weapon = 3
        {
			if (have_Rocket_Launcher == true) {
				Null ();
				weapon3.SetActive (true);//activate 3 weapon
				weapon3.GetComponent<Animation> ().Play ("RocketLauncher_On");
			}
        }

		if (current_Weapon == 4)// if current weapon = 4
        {
			if (have_Machine == true) {
				Null ();
				weapon4.SetActive (true);//activate 4 weapon
				weapon4.GetComponent<Animation> ().Play ("Machine_On");
			}
        }

		if (current_Weapon == 5)// if current weapon = 5
        {
			if (have_Flamethrower == true) {
				Null ();
				weapon5.SetActive (true);//activate 5 weapon
				weapon5.GetComponent<Animation> ().Play ("Flamethrower_On");
			}
        }

		if (current_Weapon == 6)// if current weapon = 6
        {
			if (have_Submachine_Gun == true) {
				Null ();
				weapon6.SetActive (true);//activate 6 weapon
				weapon6.GetComponent<Animation> ().Play ("Submachinegun_On");
			}
        }

		if (current_Weapon == 7)// if current weapon = 7
        {
			if (have_Knife == true) {
				Null ();
				weapon7.SetActive (true);//activate 7 weapon
				weapon7.GetComponent<Animation> ().Play ("Knife_On");
			}
        }
    }
}


