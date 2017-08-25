using UnityEngine;
using System.Collections;


	

public class WeaponManager : MonoBehaviour
{
	public int current_Weapon;// current weapon
	public bool can_change_weapons;
	public bool pick_up_off=true;

    public GameObject weapon1;//weapon 1 prefab
	public GameObject weapon2;//weapon 2 prefab
	public GameObject weapon3;//weapon 3 prefab
	public GameObject weapon4;//weapon 4 prefab
	public GameObject weapon5;//weapon 5 prefab
	public GameObject weapon6;//weapon 6 prefab
	public GameObject weapon7;//weapon 7 prefab

	public RocketLauncher rocket_launcher;	//
    public Gun gun;    						//
    public SnaiperRifle snaiper_rifle;		//
    public Machine machine;     			// links to weapons scripts
    public Flamethrower flamethrower;		//
	public Submachinegun submachinegun;     //
    public Knife knife;          			//

    private int weapon1_mode;
    private int weapon2_mode;
    private int weapon3_mode;
    private int weapon4_mode;
	private int weapon5_mode;
	private int weapon6_mode;
    private int weapon7_mode;

    public GameObject hptexture;  //
    public GameObject pattexture; //
    public GameObject grentexture;// ammo,health textures
    public GameObject hptext;     //
    public GameObject pattext;    //
    public GameObject grentext;   //

	public bool have_Gun = false;
	public bool have_Machine = false;
	public bool have_Rocket_Launcher = false;
	public bool have_Flamethrower = false;
	public bool have_Submachine_Gun = false;
	public bool have_Knife = false;
	public bool have_Sniper_rifle = false;


    void Start()
    {
		if (pick_up_off == true) {
			have_Gun = true;
			have_Machine = true;
			have_Rocket_Launcher = true;
			have_Flamethrower = true;
			have_Submachine_Gun = true;
			have_Knife = true;
			have_Sniper_rifle = true;
		} else {
			have_Gun = false;
			have_Machine = false;
			have_Rocket_Launcher = false;
			have_Flamethrower = false;
			have_Submachine_Gun = false;
			have_Knife = false;
			have_Sniper_rifle = false;
		}
		Null_Weapons();
		Null_Weapons_mode ();
        

        pattexture.SetActive(true);  //
        grentexture.SetActive(true); // 
        hptexture.SetActive(true);   //
        hptext.SetActive(true);      // activate all textures
        pattext.SetActive(true);     //
        grentext.SetActive(true);    //

    }

    void Update()
    {

		if (snaiper_rifle.aim == false & gun.aim == false & machine.aim == false & submachinegun.aim == false) // if aim off
		{
			can_change_weapons = true;
		} 
		else 
		{
			can_change_weapons = false;
		}


		if ((Input.GetAxis ("Mouse ScrollWheel")< 0)||(Input.GetButtonDown("Weapon down"))  & can_change_weapons==true)// if sroll mouse button (up) and aim off(all weapons)
        {
			current_Weapon -= 1;
			Switch(); // switch weapon
        }
		if ((Input.GetAxis ("Mouse ScrollWheel") > 0) ||(Input.GetButtonDown("Weapon up")) & can_change_weapons==true)// if sroll mouse button (down)and aim off(all weapons)
        {
			current_Weapon += 1;
			Switch(); // switch weapon
        }
		if (current_Weapon > 7)
        {
			current_Weapon = 1;
			Switch(); // switch weapon
        }
		if (current_Weapon < 1)
        {
			current_Weapon = 7;
			Switch(); // switch weapon
        }
		if (Input.GetKeyDown("1") & can_change_weapons==true)// if press "1",and aim off(all weapons)
        {
            if (weapon1_mode == 0)// if gun inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon1_mode = 1;      
				current_Weapon = 1; 
				Switch(); // switch weapon
            }
        }
		if (Input.GetKeyDown("2") & can_change_weapons==true)//if press "2",and aim off(all weapons)
        {
			if (weapon2_mode == 0)// if gun inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon2_mode = 1;   
				current_Weapon = 2;
				Switch(); // switch weapon 
            }
        }
		if (Input.GetKeyDown("3") & can_change_weapons==true)//if press "3",and aim off(all weapons)
        {
			if (weapon3_mode == 0)// if rocket launcher inactive
            {

				Null_Weapons_mode ();// deactivate all weapons
				weapon3_mode = 1;   
				current_Weapon = 3;
				Switch(); // switch weapon

            }
        }
		if (Input.GetKeyDown("4") & can_change_weapons==true)//if press "4",and aim off(all weapons)
        {
            if (weapon4_mode == 0)// if machine gun inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon4_mode = 1;  
				current_Weapon = 4;
				Switch(); // switch weapon

			}
        }

		if (Input.GetKeyDown("5") & can_change_weapons==true)//if press "5",and aim off(all weapons)
        {
			if (weapon5_mode == 0) // if flamethrower inactive
			{

				Null_Weapons_mode ();// deactivate all weapons
				weapon5_mode = 1;  
				current_Weapon = 5;
				Switch (); // switch weapon
			}
        }

		if (Input.GetKeyDown("6") & can_change_weapons==true)//if press "6",and aim off(all weapons)
        {
			if (weapon6_mode == 0)// if laser inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon6_mode = 1;
				current_Weapon = 6;
				Switch(); // switch weapon   
            }
        }

		if (Input.GetKeyDown("7") & can_change_weapons==true)//if press "7",and aim off(all weapons)
        {
			if (weapon7_mode == 0)// if knife inactive
            {
				Null_Weapons_mode ();// deactivate all weapons
				weapon7_mode = 1;    
				current_Weapon = 7;
				Switch(); // switch weapon
            }
        }

		if (Input.GetKeyDown("0") & can_change_weapons==true)//if press "0",and aim off(all weapons)
        {
			Null_Weapons();
			Null_Weapons_mode ();
        }

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


   public void Null_Weapons()
    {
		weapon1.SetActive(false);//
		weapon2.SetActive(false);//
		weapon3.SetActive(false);//
		weapon4.SetActive(false);// deactivate all weapons 
		weapon5.SetActive(false);//
		weapon6.SetActive(false);//
		weapon7.SetActive(false);//

    }
   public void Switch()// switch weapons
    {

		if (current_Weapon == 1) {
			if (have_Gun == true) {
				Null_Weapons ();
				weapon1.SetActive (true);//activate 1 weapon
				weapon1.GetComponent<Animation>().Play("Gun_On");			
			}
		}
			
		if (current_Weapon == 2) {
			if (have_Sniper_rifle == true) {
				Null_Weapons ();
				weapon2.SetActive (true);//activate 2 weapon
				weapon2.GetComponent<Animation>().Play("SniperRifle_On");
			}
		}

		if (current_Weapon == 3) {
			if (have_Rocket_Launcher == true) {
				Null_Weapons ();
				weapon3.SetActive (true);//activate 3 weapon
				weapon3.GetComponent<Animation>().Play("RocketLauncher_On");
			}
		}

		if (current_Weapon == 4) {
			if (have_Machine == true) {
				Null_Weapons ();
				weapon4.SetActive (true);//activate 4 weapon
				weapon4.GetComponent<Animation>().Play("Machine_On");
			}
		}

		if (current_Weapon == 5) {
			if (have_Flamethrower == true) {
				Null_Weapons ();
				weapon5.SetActive (true);//activate 5 weapon
				weapon5.GetComponent<Animation>().Play("Flamethrower_On");
			}
		}

		if (current_Weapon == 6) {
			if (have_Submachine_Gun == true) {
				Null_Weapons ();
				weapon6.SetActive (true);//activate 6 weapon
				weapon6.GetComponent<Animation>().Play("Submachinegun_On");
			}
		}

		if (current_Weapon == 7) {
			if (have_Knife == true) {
				Null_Weapons ();
				weapon7.SetActive (true);//activate 7 weapon
				weapon7.GetComponent<Animation>().Play("Knife_On");
			}
		}

    }


}


