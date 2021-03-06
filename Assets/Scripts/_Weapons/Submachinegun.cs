using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Submachinegun : MonoBehaviour
{
    public int lasermode;//animation mode
    private float laserreload;
    public int curAmmo = 0;// curent ammo
    public int maxAmmo = 12;// max ammo
    public int inventoryAmmo = 24;// ammo in inventory
    public Transform camera1;// fpc camera
    public Transform metalHit;// texture of holes from bullets
    public Transform MetalSparks;// sparks from bullet
    public Transform MuzzleFlash;// fire shoot
    private RaycastHit Hit;// raycast ray
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;
    private float timeout = 0.2f;// timer
    public AudioClip Shoot;   // audio
    public AudioClip Reloaded;//
    public float Accuracy = 0.01f;//accuracy of bullets
    public Light Light; // light when shoot
    public Text bulletGUI; // text which shows the current ammo
    public int damage; // robots damage

    public AnimationClip _Idle;    //
    public AnimationClip _Reload;  //
    public AnimationClip _Shoot;   //
    public AnimationClip _AimIdle; // Animations
    public AnimationClip _AimOn;   //
    public AnimationClip _AimOff;  //
    public AnimationClip _AimShoot;//
    string _idle_;
    string _reload_;
    string _shoot_;
    string _aimidle_;
    string _aimon_;
    string _aimoff_;
    string _aimshoot_;

    public bool aim;// can aim

    void Start()
    {

    }

    void Update()
    {

        _idle_ = _Idle.name;        //
        _reload_ = _Reload.name;    //
        _shoot_ = _Shoot.name;      // get name of animation
        _aimon_ = _AimOn.name;      //
        _aimidle_ = _AimIdle.name;  //
        _aimoff_ = _AimOff.name;    //
        _aimshoot_ = _AimShoot.name;//

        //start animation

        if (lasermode == 0)
        {
            GetComponent<Animation>().CrossFade(_idle_);// idle animation
        }
        if (lasermode == 1)
        {
            GetComponent<Animation>().Play(_aimon_);// aim on animation
            lasermode = 3;// animation mode
        }
        if (lasermode == 2)
        {
            GetComponent<Animation>().Play(_aimoff_);// aim off animation
            lasermode = 0;// animation mode
        }
        if (lasermode == 3)
        {
            GetComponent<Animation>().CrossFade(_aimidle_);// aim idle animation
        }
        if (lasermode == 4)
        {
            GetComponent<Animation>().CrossFade(_reload_);// reload animation
            laserreload += Time.deltaTime;
        }
        if (laserreload >= GetComponent<Animation>()[_reload_].length)// if end animation
        {
            Reload();
            lasermode = 0;// animation mode
            laserreload = 0;
        }

        //end animation

        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
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
		if (Input.GetButtonDown("Aim") && aim == false & lasermode == 0)// if aim on
        {
			
            lasermode = 1;// animation mode
            camera1.GetComponent<Camera>().fieldOfView = 30;// camera depth = 30
            aim = true;

			camera1.GetComponent<MouseLook> ().sensitivityX = 3;//sensitivity change
			camera1.GetComponent<MouseLook> ().sensitivityY = 3;//sensitivity change
		//	GameObject.FindWithTag ("Player").GetComponent<MouseLook>().sensitivityX=3;//sensitivity change
        }
        else
			if (Input.GetButtonDown("Aim") && aim == true)//if aim off
			{
            lasermode = 2;// animation mode
            camera1.GetComponent<Camera>().fieldOfView = 60;// camera depth = 60
            aim = false;

			camera1.GetComponent<MouseLook> ().sensitivityX = 10;//sensitivity change
			camera1.GetComponent<MouseLook> ().sensitivityY = 10;//sensitivity change
		//	GameObject.FindWithTag ("Player").GetComponent<MouseLook>().sensitivityX=15;//sensitivity change
			}
			
			
        

		if (Input.GetButton("Attack") & _rateofSpeed > RateOfSpeed & (lasermode == 0 || lasermode == 3) & curAmmo > 0)// if shoot
        {
            timeout = 0;
			GetComponent<AudioSource>().PlayOneShot(Shoot);// play audio
            if (aim == true)
            {

                GetComponent<Animation>().Play(_aimshoot_);// aim shoot animation
            }
            else
            {
                GetComponent<Animation>().Play(_shoot_);// shoot animation
            }

            Vector3 Direction = camera1.TransformDirection(Vector3.forward + new Vector3(Random.Range(-Accuracy, Accuracy), Random.Range(-Accuracy, Accuracy), 0));//accuracy of bullet
            curAmmo -= 1;//ammo consumption
            _rateofSpeed = 0;
            MuzzleFlash.GetComponent<ParticleEmitter>().emit = true;// 
            if (Physics.Raycast(camera1.position, Direction, out Hit, 1000f))// create raycast ray
            {

                if (Hit.collider.CompareTag("Robot"))//If ray hit robot
                {
					Hit.collider.GetComponent<Robot_Destroy>().Robot_health -= Hit.collider.GetComponent<Robot_Destroy>().submachinegun_damage;// robot health - damage
                }
                if (Hit.collider.CompareTag("Enemy")) {
                    Hit.collider.GetComponent<EnemyHealth>().TakeDamage(10);
                }
                Quaternion HitRotation = Quaternion.FromToRotation(Vector3.up, Hit.normal);// create bullet hole


                if (Hit.transform.GetComponent<Rigidbody>())// if ray hit rigidbody object
                {
                    Hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(Direction * 500, Hit.point);// object push
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
		if (Input.GetButtonDown("Reload") & inventoryAmmo > 0 & curAmmo != maxAmmo)// if reload
        {
            camera1.GetComponent<Camera>().fieldOfView = 60;//
            aim = false;                                    // aim off
            GetComponent<AudioSource>().PlayOneShot(Reloaded, 0.7f);// play audio
            lasermode = 4;// animation mode

			camera1.GetComponent<MouseLook> ().sensitivityX = 10;//sensitivity change
			camera1.GetComponent<MouseLook> ().sensitivityY = 10;//sensitivity change
			//GameObject.FindWithTag ("Player").GetComponent<MouseLook>().sensitivityX=15;//sensitivity change
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
		
    void OnGUI()//draw current ammo
    {
        bulletGUI.text = "" + curAmmo + "/" + inventoryAmmo;
    }
}


