using NPBehave;
using UnityEngine;
using UnityEngine.AI;

public class SoilderBT : MonoBehaviour {
    private Vector3 playerPosition;
    public GameObject player;
    private EnemyHealth characterHealth;
    private NavMeshAgent navigation;
    private Root behavourTree;
    private Animator animator;
    public float dano;
    public float speed;
    private PLayerHealt playerHealt;
    private float timePassed;
    // Use this for initialization
    void Start() {
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerHealt = GetComponent<PLayerHealt>();
        characterHealth = GetComponent<EnemyHealth>();
        behavourTree = new Root(
            //First
            new Service(0,CheckCharacterHealth,
            new Selector(
                new BlackboardCondition("characterHealth", Operator.IS_SMALLER_OR_EQUAL, 0, Stops.IMMEDIATE_RESTART,
                new Sequence(
                     new Action(() => PlayDeadAnimaton()),
                    new Action(() => DeactivateCharacter())
                    )),
            //Second leaf
            new Service(0, CheckPlayerDistance,
            new Selector(
                new BlackboardCondition("playerDistance", Operator.IS_SMALLER, 5f, Stops.IMMEDIATE_RESTART,
                new Sequence(
                    new Action(() => PlayHitAnimation()),
                    new Action(() => MakeHarmToEnemy()),
                    new Action(() => PlayIdleAnimation()),
                    new Action((bool shouldCancel)=>
                    {
                        if (!shouldCancel) {
                            Rest();
                            return Action.Result.PROGRESS;
                        }
                        else {
                            return Action.Result.FAILED;

                        }
                    })
                    
                )),
            //Third leaf
            new Service(0, CheckPlayerDistance,
            new Selector(
                new BlackboardCondition("playerDistance", Operator.IS_GREATER_OR_EQUAL, 5f, Stops.IMMEDIATE_RESTART,
                new Sequence(
                    new Action(() => PlayRunAnimation()),
                    new Action(() => PursuitEnemy())
                ))
                ))
                    )
            )
           )));
     
        behavourTree.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Actions

    private void PlayDeadAnimaton() {
        animator.SetTrigger("ToDie");
    }
    private void PlayIdleAnimation() {
        animator.SetTrigger("ToIdle");
    }
    private void PlayHitAnimation() {
        animator.SetTrigger("ToAttack");
    }
    private void PlayRunAnimation() {
        animator.SetTrigger("ToWalk");
    }
    private void DeactivateCharacter() {
        Debug.Log("Deactivate Character");
        this.gameObject.SetActive(false);
    }
    private void MakeHarmToEnemy() {
        playerHealt.ReciveDamage(dano);
    }
    private void Rest()
    {
        timePassed = Time.deltaTime;
    }
    private void PursuitEnemy() {
        navigation.SetDestination(player.transform.position);
    }
    //Variables

    private void CheckCharacterHealth() {
        behavourTree.Blackboard["characterHealth"] = characterHealth.currentHealth;
    }
    private void CheckPlayerDistance() {
              behavourTree.Blackboard["playerDistance"] = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
    }
}

