using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
    private StateMachine zombieStateMachine;

    //Jugador
    public GameObject player;
    //Atributos
    public float speed;
    public float dano;
    public Transform[] goals;
    //Estados
    private StatePursuitEnemy statePursuitEnemy = new StatePursuitEnemy();
    private StateDeath stateDeath = new StateDeath();
    private StateHitEnemy stateHitEnemy = new StateHitEnemy();
    private StateIdle stateIdle = new StateIdle();
    private Animator animator;
    // Use this for initialization

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        
        statePursuitEnemy.myTransform = transform;
        statePursuitEnemy.me = this.gameObject;
        statePursuitEnemy.enemy = player.transform;
        statePursuitEnemy.speed = speed;


        zombieStateMachine = new StateMachine(statePursuitEnemy);
        zombieStateMachine.states = new State[] { statePursuitEnemy, stateHitEnemy, stateDeath, stateIdle };

        //Espacio para las variables de stateHitEnemy
        stateHitEnemy.myTransform = transform;
        stateHitEnemy.enemy = player;
        stateHitEnemy.dano = dano;
        //Espacio para las variables de stateDeath 
        stateDeath.me = this.gameObject;

        Transition pursuit2Hit = new Transition();
        pursuit2Hit.targetState = stateHitEnemy;
        pursuit2Hit.action = FromWalking2HitAction;
        pursuit2Hit.IsTriggered = IsEnable2HitFromPursuit;

        Transition hit2Death = new Transition();
        hit2Death.targetState = stateDeath;
        hit2Death.action = FromHit2DeathAction;
        hit2Death.IsTriggered = IsEnable2DieFromHit;

        Transition pursuit2Death = new Transition();
        pursuit2Death.targetState = stateDeath;
        pursuit2Death.action = FromWalking2DeathAction;
        pursuit2Death.IsTriggered = IsEnable2DieFromPursuit;

        Transition death2Pursuit = new Transition();
        death2Pursuit.targetState = statePursuitEnemy;
        death2Pursuit.action = FromDeath2WalkingAction;
        death2Pursuit.IsTriggered = IsEnable2PursuitFromDeath;

        Transition hit2Idle = new Transition();
        hit2Idle.targetState = stateIdle;
        hit2Idle.action = FromAtack2IdleAction;
        hit2Idle.IsTriggered = IsEnable2RestFromHit;

        Transition idle2Walking = new Transition();
        idle2Walking.targetState = statePursuitEnemy;
        idle2Walking.action = FromIdle2WalkingAction;
        idle2Walking.IsTriggered = IsEnable2PursuitFromIdle;

        Transition idle2Die= new Transition();
        idle2Walking.targetState = stateDeath;
        idle2Walking.action = FromIdle2DeathAction;
        idle2Walking.IsTriggered = IsEnable2DieFromIdle;

        stateDeath.transitions = new Transition[] {death2Pursuit};
        statePursuitEnemy.transitions = new Transition[] { pursuit2Hit, pursuit2Death };
        stateHitEnemy.transitions = new Transition[] {hit2Death, hit2Idle };
        stateIdle.transitions = new Transition[] {idle2Walking, idle2Die};
    }
    private bool IsEnable2PursuitFromDeath() {
        return stateDeath.IsEnable2PursuitFromDeath();
    }
    private bool IsEnable2DieFromIdle() {
        return stateIdle.ImDead();
    }
    private bool IsEnable2HitFromPursuit() {
        return statePursuitEnemy.enemyOnAtackZone();
    }
    private bool IsEnable2PursuitFromHit() {
        return stateHitEnemy.Isfar();
    }
    private bool IsEnable2RestFromHit() {
        return stateHitEnemy.JustFinishHitting();
    }
    private bool IsEnable2DieFromHit() {
        return stateHitEnemy.ImDead();
    }
    private bool IsEnable2DieFromPursuit() {
        return statePursuitEnemy.ImDead();
    }
    private bool IsEnable2PursuitFromIdle() {
        return stateIdle.timeIsOver();
    }
    public void FromWalking2HitAction() {
       animator.SetTrigger("W2A");
        Debug.Log("Walking2Hit");
    }
    public void FromAtack2IdleAction() {
        animator.SetTrigger("A2I");
        Debug.Log("Walking2Hit");
    }
    public void FromHit2WalkingAction()
    {
        animator.SetTrigger("W2A");
        Debug.Log("Hit2Walking");
    }
    public void FromIdle2DeathAction()
    {
        animator.SetTrigger("I2D");
        Debug.Log("idle2Death");
    }
    public void FromIdle2WalkingAction()
    {
        animator.SetTrigger("A2W");
        Debug.Log("idle2Walking");
    }
    public void FromWalking2DeathAction()
    {
        animator.SetTrigger("W2D");
        Debug.Log("Walking2Death");
    }
    public void FromHit2DeathAction()
    {
        animator.SetTrigger("A2D");
        Debug.Log("Hit2Death");
    }
    public void FromDeath2WalkingAction()
    {
        animator.SetTrigger("D2W");
        Debug.Log("Death2Wallking");
    }
    // Update is called once per frame
    void Update ()
	{
		Action actions = zombieStateMachine.Update();
		actions();
	}
}

