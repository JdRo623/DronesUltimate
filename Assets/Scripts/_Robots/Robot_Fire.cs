using UnityEngine;
using System.Collections;

public class Robot_Fire : MonoBehaviour
{

    public GameObject[] InnerCore; //
    public GameObject[] OuterCore; // fire
    public GameObject[] Smoke;     //
    public GameObject[] Li; // lights
    public GameObject[] Col; // fire coliders

	public Robot_Move robot_move;//links to robot script (walk)

    void Start()
    {
        for (int i = 0; i < InnerCore.Length; i++)
        {
            InnerCore[i].GetComponent<ParticleEmitter>().emit = false;//
            OuterCore[i].GetComponent<ParticleEmitter>().emit = false;// deactivation fire
            Smoke[i].GetComponent<ParticleEmitter>().emit = false;    //
			Li[i].SetActive(false);// deactivation lights
            Col[i].GetComponent<Collider>().enabled = false; // deactivation fire colliders
        }
    }

    void Update()
    {

        if (robot_move.CanShoot == true)// shoot
        {
            for (int i = 0; i < InnerCore.Length; i++)
            {
                InnerCore[i].GetComponent<ParticleEmitter>().emit = true;//
                OuterCore[i].GetComponent<ParticleEmitter>().emit = true;// activation fire
                Smoke[i].GetComponent<ParticleEmitter>().emit = true;    //
				Li[i].SetActive(true);//activation lights
                Col[i].GetComponent<Collider>().enabled = true;//activation fire colliders
            }
        }
        else
        {
            for (int i = 0; i < InnerCore.Length; i++)
            {
                InnerCore[i].GetComponent<ParticleEmitter>().emit = false;//
                OuterCore[i].GetComponent<ParticleEmitter>().emit = false;//deactivation fire
                Smoke[i].GetComponent<ParticleEmitter>().emit = false;    //
				Li[i].SetActive(false);//deactivation lights
                Col[i].GetComponent<Collider>().enabled = false;//deactivation fire colliders
            }

        }

    }
}
