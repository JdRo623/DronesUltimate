using UnityEngine;
using System.Collections;
using System;

public class StateHitEnemy : State {
    public Transform myTransform;
    public GameObject enemy;
    public float dano;
    private EnemyHealth myHealt;
    private Health playerHealt;
    private bool isDead;
    private bool FinishHit;
    private float animationTime;
    private float currentAnimationTime;

    public override void OnEntryAction()
    {
        myHealt = myTransform.GetComponent<EnemyHealth>();
        playerHealt = enemy.GetComponent<Health>();
        animationTime = (myTransform.gameObject.GetComponent<Animator>()).GetNextAnimatorStateInfo(0).length;
        isDead = false;
        FinishHit = false;
        Debug.Log("HitEnemyOnEntry");
    }

    public override void OnUpdateAction()
    {
        myHealt = myTransform.GetComponent<EnemyHealth>();
        playerHealt = enemy.GetComponent<Health>();
        //Activar animacion de golpear
        if (myHealt.currentHealth <= 0)
        {
            isDead = true;
        }
        playerHealt.damage(dano);
        Debug.Log("Daño");
        FinishHit = true;
        currentAnimationTime = (myTransform.gameObject.GetComponent<Animator>()).GetNextAnimatorStateInfo(0).normalizedTime;
        
    }

    public override void OnExitAction()
    {
        isDead = false;
    }
    public bool justHit() {
        Debug.Log(FinishHit);
        return FinishHit;
    }
    public bool JustFinishHitting() {
        Debug.Log(FinishHit);
        return FinishHit;

    }
    public bool ImDead()
    {
        return isDead;
    }

    internal bool Isfar()
    {
        return Vector3.Distance(myTransform.position, enemy.transform.position) > 3;
    }
}
