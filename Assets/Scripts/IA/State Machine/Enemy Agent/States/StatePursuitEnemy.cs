using UnityEngine;
using System.Collections;

public class StatePursuitEnemy : State {
	public Transform enemy;
	public float speed;
	private Vector3 direcction;
    public GameObject me;
	public Transform myTransform;
    private EnemyHealth myHealt;
    private bool isDead = false;
    private float distance2Harm = GameHandler.distance2Hit;

    public override void OnEntryAction(){
        distance2Harm = GameHandler.distance2Hit;
    }
	
	public override void OnUpdateAction(){
        if (me.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            isDead = true;
        }

        UnityEngine.AI.NavMeshAgent nav = me.GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.SetDestination(enemy.position);
	}
	
	public override void OnExitAction(){
        isDead = false;
	}
	public void transformRotation(){
		float orientation = Mathf.Atan2(direcction.x,direcction.z);
		orientation *= Mathf.Rad2Deg;
		Quaternion newRotation = new Quaternion();
		newRotation.eulerAngles = new Vector3(0,orientation,0);
		myTransform.rotation = newRotation;
	}
    public bool enemyOnAtackZone() {
        return Vector3.Distance(myTransform.position, enemy.position) <= distance2Harm;
    }
    public bool ImDead(){
        return isDead;
    }
}
