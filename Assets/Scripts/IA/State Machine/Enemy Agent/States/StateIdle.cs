using UnityEngine;
using System.Collections;

public class StateIdle : State
{
    public GameObject me;
	public Transform myTransform;
	public Transform enemy;
    private EnemyHealth myHealt;
    private bool isDead;
    private float timer;
	public override void OnEntryAction(){
      //  myHealt = me.GetComponent<EnemyHealth>();
        isDead = false;
        timer = 0;
	}
	
	public override void OnUpdateAction(){

        if (me.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            isDead = true;
        }
        timer += Time.deltaTime;
        
	}
	
	public override void OnExitAction(){
        isDead = false;
        timer = 0;
	}
	//public bool enemyClose(){
	//	return Vector3.Distance (myTransform.position, enemy.position) < 1;
	//}
    public bool ImDead() {
        
        return isDead;
    }
    public bool timeIsOver() {
        return timer >= 3;
    }
}

