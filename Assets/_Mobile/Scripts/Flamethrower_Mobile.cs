using UnityEngine; 
using System.Collections;

public class Flamethrower_Mobile : MonoBehaviour
{

    public GameObject InnerCore;//
    public GameObject OuterCore;// Fire
    public GameObject Smoke;    //
    public GameObject Li;// light
    public int firemode;//animation mode
    private float firereload;
    public AudioClip Shoot;   // audio
    public AudioClip Reloaded;//
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    public GUIText bulletGUI;// text which shows the current ammo
    public GUITexture shoot_gui;
    public GUITexture aim_gui;

    public AnimationClip _Idle;  //
    public AnimationClip _Reload;// Animations
    public AnimationClip _Shoot; //
    public AnimationClip _GunOn; //
    string _idle_;
    string _reload_;
    string _shoot_;
    string _gunon_;


    void Start()
    {
        InnerCore.GetComponent<ParticleEmitter>().emit = false;// 
        OuterCore.GetComponent<ParticleEmitter>().emit = false;// deactivation fire
        Smoke.GetComponent<ParticleEmitter>().emit = false;    //
		Li.SetActive(false);// deactivation light
        GameObject.Find("FireCollider").GetComponent<Collider>().enabled = false;// deactivation fire collider
    }

    void Update()
    {

        _gunon_ = _GunOn.name;  //
        _idle_ = _Idle.name;    //get name of animation
        _reload_ = _Reload.name;//
        _shoot_ = _Shoot.name;  //


        if (firemode == 0)
        {
            GetComponent<Animation>().CrossFade(_idle_);// idle animation
        }
        if (firemode == 4)
        {
            GetComponent<Animation>().CrossFade(_reload_);// reload animation
            firereload += Time.deltaTime;
        }
        if (firereload >= GetComponent<Animation>()[_reload_].length)// if end animation
        {
            Reload();
            firemode = 0;
            firereload = 0;
        }


        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (shoot_gui.HitTest(touch.position) & touch.phase == TouchPhase.Stationary & firemode == 0 & curAmmo > 0)// if shoot
            {
                GetComponent<Animation>().CrossFade(_shoot_);// play animation - shoot
                curAmmo -= 1;//ammo consumption
				Li.SetActive(true);// light activate
                InnerCore.GetComponent<ParticleEmitter>().emit = true;//
                OuterCore.GetComponent<ParticleEmitter>().emit = true;// activation fire
                Smoke.GetComponent<ParticleEmitter>().emit = true;    //
                GameObject.Find("FireCollider").GetComponent<Collider>().enabled = true;// activation fire collider
            }
            else
            {
				Li.SetActive(false);//deactivation light
                InnerCore.GetComponent<ParticleEmitter>().emit = false;//
                OuterCore.GetComponent<ParticleEmitter>().emit = false;//deactivation fire
                Smoke.GetComponent<ParticleEmitter>().emit = false;    //
                GameObject.Find("FireCollider").GetComponent<Collider>().enabled = false;//deactivation fire collider

            }

            if (curAmmo == 0 & curAmmo != maxAmmo)
            {
                GetComponent<AudioSource>().PlayOneShot(Reloaded, 0.7f);
                firemode = 4;
            }
        }
    }
    public void Reload()//ammo calculation
    {
        if (inventoryAmmo < maxAmmo - curAmmo)
        {
            curAmmo += inventoryAmmo;
            inventoryAmmo = 0;
        }
        else
        {
            inventoryAmmo -= maxAmmo - curAmmo;
            curAmmo += maxAmmo - curAmmo;
        }
    }

    public void GUNON()//gun on
    {
        _gunon_ = _GunOn.name;//get animation name
        GetComponent<Animation>().Play(_gunon_);// animation play
        firemode = 0;// animation mode
    }
    void OnGUI()//draw current ammo
    {
        bulletGUI.text = "" + curAmmo / 10 + "/" + inventoryAmmo / 10;
    }
}
