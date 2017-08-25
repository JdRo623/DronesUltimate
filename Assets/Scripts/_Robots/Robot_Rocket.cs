using UnityEngine;
using System.Collections;

public class Robot_Rocket : MonoBehaviour
{
    public Transform Top;// robot top
    public Transform[] RocketRespawn; //rocket spawn points
    public Transform rocket;// rocket prefab
	public Robot_Move robot_move;//links to walk script
    public float RateOfSpeed = 0.5f;// rate of shoot
    private float _rateofSpeed;



    void Start()
    {
        for (int i = 0; i < RocketRespawn.Length; i++)
        {
            Transform go = Instantiate(rocket, RocketRespawn[i].position, RocketRespawn[i].rotation) as Transform;
            go.parent = Top; // create rockets
        }


    }
    void Update()
    {
        if (_rateofSpeed <= RateOfSpeed)//rate of shoot
        {
            _rateofSpeed += Time.deltaTime;
        }

        if (robot_move.CanShoot == true & _rateofSpeed > RateOfSpeed)// shoot
        {
            Shot();
        }
    }
    public void Relod()
    {

        for (int i = 0; i < RocketRespawn.Length; i++)
        {
            Transform go = Instantiate(rocket, RocketRespawn[i].position, RocketRespawn[i].rotation) as Transform;
            go.parent = Top; // crete rockets
        }

    }
    public void Shot()
    {
        Transform rocket = Top.transform.Find("rocket2(Clone)");// find rocket
        rocket.GetComponent<Rocket>().Activate = true;// activation rocket
        rocket.parent = null;
        Relod();
        _rateofSpeed = 0;
    }
}
      

	