using UnityEngine;
using System.Collections;

public class Grenade_Launcher : MonoBehaviour
{

    public Rigidbody grenade;// grenade prefab
    public float speed = 20;// grenade speed
    public int Ammo = 10;// curent ammo
    public GUIText bulletGUI;// text which shows the current ammo



    void Update()
    {


        if (Input.GetButtonDown("Grenade") & Ammo > 0)// if shoot
        {
            Ammo -= 1;//ammo consumption
            Rigidbody grenadeclone = (Rigidbody)Instantiate(grenade, transform.position, transform.rotation);// create grenade
            grenadeclone.velocity = transform.TransformDirection(Vector3.forward * speed);// push grenade
        }
    }

    void OnGUI()//draw current ammo
    {

        bulletGUI.text = "" + Ammo;
    }
}



