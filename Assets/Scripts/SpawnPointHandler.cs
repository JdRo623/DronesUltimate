﻿using UnityEngine;
using System.Collections;

public class SpawnPointHandler : MonoBehaviour {

    // Use this for initialization
    public EnemyPoolScript spiderDronePool;
    public GameObject player;

    public int createEnemy(int numberOfEnemys2Spawn, bool boss)
    {
        GameObject obj = spiderDronePool.GetPulledObject();
        if (obj != null)
        {
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.GetComponent<StateMachineEnemyHandler>().player = player;
            obj.GetComponent<EnemyHealth>().isDead = false;
            obj.SetActive(true);
            numberOfEnemys2Spawn--;
        }
        return numberOfEnemys2Spawn;
    }
}