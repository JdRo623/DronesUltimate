using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Knife : MonoBehaviour
{
    public GameObject col; // knife collider
    public AnimationClip _Idle;  //
    public AnimationClip _Attack;// animations
    public AnimationClip _GunOn; //
    string _idle_;
    string _shoot_;
	public AudioClip attack;
	public Text AmmoGUI;// text which shows the current ammo

    void Start()
    {
        col.SetActive(false);//deactivation knife collider
    }


    void Update()
	{

		_idle_ = _Idle.name;   // get name of animation      
		_shoot_ = _Attack.name;//

		GetComponent<Animation> ().CrossFade (_idle_);// play animation "idle"

		if (Input.GetButton  ("Attack")) {
			GetComponent<AudioSource>().PlayOneShot(attack);// play audio
			GetComponent<Animation> ().Play (_shoot_);// play animation shoot
			col.SetActive (true);// activation knife collider 
		} else {
			col.SetActive (false);//deactivation knife collider
		}

	}
	void OnGUI()//draw current ammo
	{

		AmmoGUI.text = "Knife" ;
	}
}

