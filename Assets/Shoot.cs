using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public int damagePerShot;
    public float speed;
    private Rigidbody rigidbody;
    private int shootableMask;

    void OnTriggerEnter(Collider other) {
        Debug.Log("Entroooo");
        Debug.Log(other.gameObject.tag == "Enemy");
        if (other.gameObject.tag == "Enemy") {
            Debug.Log("Entro");
            EnemyHealth eh = other.GetComponent<EnemyHealth>();
            if (eh!=null) {
              //  eh.TakeDamage(damagePerShot,new Vector3(0,0,0));
            }
        }
        if (other.gameObject.tag != "Bala")
        this.gameObject.active = false;
    }
      void OnEnable() {
        shootableMask = LayerMask.GetMask("Shootable");
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity=((transform.forward) * speed);
      }
}
