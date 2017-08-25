using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour
{
    public Transform physicExplosion;// physic explosion prefab
    public Transform graphicExplosion;// explosition prefab
    float timer = 0;//timer
    bool canExplosion;// can shoot

    void Update()
    {
        if (timer < 3)//start timer
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3 || canExplosion == true)// if shoot 
        {
            Instantiate(physicExplosion, transform.position + transform.TransformDirection(Vector3.forward) * 1.4f, transform.rotation);// create physic explosion prefab
            Instantiate(graphicExplosion, transform.position + transform.TransformDirection(Vector3.forward) * 1.4f, transform.rotation);// create explosition prefab
            Destroy(gameObject);//destroy grenade
            canExplosion = false;
        }
    }
    void OnTriggerEnter(Collider Col)//if grenade hit robot
    {
        if (Col.tag == "Robot")
        {
            canExplosion = true;
        }
    }
}
