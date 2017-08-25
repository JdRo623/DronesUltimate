using UnityEngine;
using System.Collections;

public class GrenadeLauncher_Mobile : MonoBehaviour
{

    public Rigidbody grenade;// grenade prefab
    public float speed = 20;// grenade speed
    public int Ammo = 10;// curent ammo
    public GUIText bulletGUI;// text which shows the current ammo
    public GUITexture shat;// "shoot" texture



    void Update()
    {


        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (shat.HitTest(touch.position) & touch.phase == TouchPhase.Began & touch.phase != TouchPhase.Stationary & Ammo > 0)// if shoot
            {
                Ammo -= 1;
                Rigidbody grenadeclone = (Rigidbody)Instantiate(grenade, transform.position, transform.rotation);// create grenade
                grenadeclone.velocity = transform.TransformDirection(Vector3.forward * speed); // push grenade
            }
        }
    }

    void OnGUI()//draw current ammo
    {

        bulletGUI.text = "" + Ammo;
    }
}
