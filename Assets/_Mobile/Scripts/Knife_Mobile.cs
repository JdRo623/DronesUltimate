using UnityEngine;
using System.Collections;

public class Knife_Mobile : MonoBehaviour
{
    public GameObject col;// knife collider
    public GUITexture shat;
    public GUIText bulletGUI;
    public AnimationClip _Idle;  //
    public AnimationClip _Attack;// animations
    public AnimationClip _GunOn; //
    string _idle_;
    string _shoot_;
    string _gunon_;

    void Start()
    {
        col.SetActive(false);//deactivation knife collider
    }

    void Update()
    {

        _gunon_ = _GunOn.name; //
        _idle_ = _Idle.name;   // get name of animation      
        _shoot_ = _Attack.name;//

        GetComponent<Animation>().CrossFade(_idle_);// play animation "idle"

        int count = Input.touchCount;
        for (int i = 0; i < count; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (shat.HitTest(touch.position) & touch.phase == TouchPhase.Stationary)//if shoot
            {
                GetComponent<Animation>().Play(_shoot_);// play animation shoot
                col.SetActive(true);// activation knife collider 
            }
            else
            {
                col.SetActive(false);//deactivation knife collider
            }
        }


    }
    public void GUNON()//gun on
    {
        _gunon_ = _GunOn.name;//get animation name
        GetComponent<Animation>().Play(_gunon_);// animation play

    }
    void OnGUI()
    {
        bulletGUI.text = "";
    }
}
