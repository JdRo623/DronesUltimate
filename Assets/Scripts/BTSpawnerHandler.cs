using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSpawnerHandler : MonoBehaviour {

    public EnemyPoolScript spiderDronePool;
    public GameObject player;

    public int createEnemy(int numberOfEnemys2Spawn, bool boss)
    {
        GameObject obj = spiderDronePool.GetPulledObject();
        if (obj != null)
        {
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.GetComponent<BehaviorTreeEnemyHandler>().player = player;
            obj.GetComponent<EnemyHealth>().isDead = false;
            obj.SetActive(true);
            numberOfEnemys2Spawn--;
        }
        return numberOfEnemys2Spawn;
    }
}
