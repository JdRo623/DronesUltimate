using UnityEngine;
using System.Collections;

public class Machine_Mobile : MonoBehaviour {
    public Transform camera1;// fpc camera
    public Transform metalHit;// texture of holes from bullets
    public Transform MetalSparks;// sparks from bullet
    public Transform MuzzleFlash;// fire shoot
    public Light Light;// light when shoot
    private RaycastHit Hit;// raycast ray
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    private float timeout = 0.2f;// timer
    public AudioClip Shoot;   // audio
    public AudioClip Reloaded;//
    public float Accuracy = 0.01f;//accuracy of bullets
    public GUITexture shoot_gui;// "shoot" gui
    public GUITexture aim_gui;// "aim" gui
    public int svumode;//animation mode
    private float svureload;
    public int damage;// robots damage
    public GUIText bulletGUI;// text which shows the current ammo

    public AnimationClip _Idle;    //
    public AnimationClip _Reload;  //
    public AnimationClip _Shoot;   //
    public AnimationClip _GunOn;   // Animations
    public AnimationClip _AimOn;   //
    public AnimationClip _AimOff;  //
    public AnimationClip _AimShoot;//
    public AnimationClip _AimIdle; //
    string _idle_;
    string _reload_;
    string _shoot_;
    string _gunon_;
	string _aimoff_;
	string _aimon_;
	string _aimshoot_;
	string _aimidle_;
 

    public bool aim;// can aim

    void start() {


    }
    void Update()
    {

        _gunon_ = _GunOn.name;      //
        _idle_ = _Idle.name;        //
        _reload_ = _Reload.name;    //
        _shoot_ = _Shoot.name;      // get name of animation
        _aimon_ = _AimOn.name;      //
        _aimidle_ = _AimIdle.name;  //
        _aimoff_ = _AimOff.name;    //
        _aimshoot_ = _AimShoot.name;//

        //start animation


        if (svumode == 0)
        {
            GetComponent<Animation>().CrossFade(_idle_);// idle animation
        }

        if (svumode == 1)
        {
            GetComponent<Animation>().Play(_aimon_);// aim on animation
            svumode = 3;// animation mode
        }
        if (svumode == 2)
        {
            GetComponent<Animation>().Play(_aimoff_);// aim off animation
            svumode = 0;// animation mode
        }
        if (svumode == 3)
        {
            GetComponent<Animation>().CrossFade(_aimidle_);// aim idle animation
        }
        //Reload
        if (svumode == 4)
        {

            GetComponent<Animation>().CrossFade(_reload_);// reload animation
            svureload += Time.deltaTime;
        }
        if (svureload >= GetComponent<Animation>()[_reload_].length)// if end animation
        {
            Reload();
            svumode = 0;// animation mode
            svureload = 0;
        }

        // end animation

        if (_rateofSpeed <= RateOfSpeed) //rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }
        if (timeout < 0.1f)// light timer
        {
            timeout += Time.deltaTime;
            Light.range = 15;
        }
        else
        {
            Light.range = 0;
        }
        int count = Input.touchCount;
        for (int i = 0; i < count; i++) {
            Touch touch = Input.GetTouch(i);



            if (aim_gui.HitTest(touch.position) & touch.phase == TouchPhase.Began & touch.phase != TouchPhase.Stationary & svumode == 0 & aim == false)// if aim on
            {
				svumode = 1;// animation mode
                camera1.GetComponent<Camera>().fieldOfView = 30;// camera depth = 30
                aim = true;
            }
            else if (aim_gui.HitTest(touch.position) & touch.phase == TouchPhase.Began & touch.phase != TouchPhase.Stationary  & aim == true)// if aim off
            {
				svumode = 2;// animation mode
                camera1.GetComponent<Camera>().fieldOfView = 60;// camera depth = 60
                aim = false;
            }

			if (shoot_gui.HitTest(touch.position) & touch.phase == TouchPhase.Stationary & _rateofSpeed > RateOfSpeed & (svumode == 0||svumode==3) & curAmmo > 0)// if shoot
            {

                timeout = 0;
                GetComponent<AudioSource>().PlayOneShot(Shoot);// play audio
                if (aim == true) {	

					GetComponent<Animation> ().Play (_aimshoot_);// aim shoot animation
                } 
				else 
				{
					GetComponent<Animation> ().Play (_shoot_);// shoot animation
                }
                Vector3 Direction = camera1.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet
                curAmmo -= 1;//ammo consumption
                _rateofSpeed = 0;
                MuzzleFlash.GetComponent<ParticleEmitter>().emit = true;

                if (Physics.Raycast(camera1.position, Direction, out Hit, 10000f))// create raycast ray
                {

                    if (Hit.collider.CompareTag("Robot"))//If ray hit robot
                    {
						Hit.collider.GetComponent<Robot_Destroy>().Robot_health -= damage;// robot health - damage
                    }
                    Quaternion HitRotation = Quaternion.FromToRotation(Vector3.up, Hit.normal);// create bullet hole
                    if (Hit.transform.GetComponent<Rigidbody>())// if ray hit rigidbody object
                    {
                        Hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 800, Hit.point);// object push
                    }
                    if (Hit.collider.material.staticFriction == 0.2f)
                    {
                        Transform metalhitGO = Instantiate(metalHit, Hit.point + (Hit.normal * 0.001f), HitRotation) as Transform;//
                        metalhitGO.transform.parent = Hit.transform;                                                              // create sparks
                        Instantiate(MetalSparks, Hit.point + (Hit.normal * 0.01f), HitRotation);                                  //
                    }
                }
            }
            else
            {
                MuzzleFlash.GetComponent<ParticleEmitter>().emit = false;
            }
        }
        if (curAmmo == 0 & curAmmo != maxAmmo)// if reload
        {
            camera1.GetComponent<Camera>().fieldOfView = 60;// aim off
            aim = false;                                    //
            GetComponent<AudioSource>().PlayOneShot(Reloaded, 0.7f);
            svumode = 4;// animation mode
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
        svumode = 0;// animation mode
    }
    void OnGUI()//draw current ammo
    {
        bulletGUI.text = "" + curAmmo + "/" + inventoryAmmo;
    }
}


				
	
	