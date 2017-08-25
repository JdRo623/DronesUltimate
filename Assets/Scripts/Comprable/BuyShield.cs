using UnityEngine;
using System.Collections;

public class BuyShield : MonoBehaviour {
    public int cost;
    public float timer=0;
    public float timeLimit;
    void OnTriggerEnter(Collider other) {
        timer = 0;
    }
    void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer>=timeLimit) {
             //   (other.gameObject.GetComponent<playerMovement>()).comprarEscudo(cost);
                this.gameObject.GetComponent<SphereCollider>().enabled = false;
            }
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
            timer = 0;
        }
        
        
    }
}
