using UnityEngine;
using System.Collections;

public class RalentizacionMira : MonoBehaviour {
    public float velocidadRotacionPrincipal;
    public float velocidadRotacionOnTarget;
    public GameObject player;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    public int range;
    // Use this for initialization

    void Start () {
        velocidadRotacionPrincipal = player.GetComponent<PlayerMovement>().velocidadRotacion;
        shootableMask = LayerMask.GetMask("Shootable");
       
    }

    void Update(){
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            player.GetComponent<PlayerMovement>().cambiarVelocidadMira(velocidadRotacionOnTarget);
        }
        else {
            player.GetComponent<PlayerMovement>().cambiarVelocidadMira(velocidadRotacionPrincipal);
        }
    }
}
