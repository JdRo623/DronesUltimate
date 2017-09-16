using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_MeleeAttack : MonoBehaviour {
	public Transform top;// link to top of robot
	public Robot_Move robot_move; // link to RobotWalk script
	public Health health; // link to health script
	private float timer;
	void Update () {

		if (robot_move.CanShoot == true) {
			timer += Time.deltaTime;
			top.transform.Rotate(0, 900 *1.2f* Time.deltaTime ,0);// rotate top 
			if (timer > 1) {
				//health.player_health -= health.melee_damage;// take health
				timer = 0;
			}
			
		}
		
	}
}
