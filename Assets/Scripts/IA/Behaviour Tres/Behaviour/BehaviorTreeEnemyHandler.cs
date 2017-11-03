using NPBehave;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class BehaviorTreeEnemyHandler : MonoBehaviour
{
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
    private float timeHitPassed;
    Stopwatch stopwatch;
    // Use this for initialization
    void Start()
    {
        stopwatch = new Stopwatch();
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerHealt = player.GetComponent<PLayerHealt>();
        characterHealth = GetComponent<EnemyHealth>();
        animator.Play("Walking");
        behavourTree = InitRoot();
        stopwatch.Start();
        behavourTree.Start();
        timePassed = 0;
        timeHitPassed = 0;
    }
    private void OnEnable()
    {
        timePassed = 0;
        timeHitPassed = 0;
    }

    //Tree

    //Actions

    private Root InitRoot() {
        return new Root(
            //First
            new Service(0, CheckCharacterHealth,
            new Selector(
                new BlackboardCondition("characterHealth", Operator.IS_SMALLER_OR_EQUAL, 0, Stops.IMMEDIATE_RESTART,
                new Sequence(
                     new Action(() => PlayDeadAnimaton()),
                     new Action((bool _shouldCancel) =>
                     {
                         if (!_shouldCancel)
                         {
                             SinkCharacter();
                             return Action.Result.PROGRESS;
                         }
                         else
                         {
                             DeactivateCharacter();
                             return Action.Result.FAILED;
                         }
                     })
                     )),
            //Second leaf
            new Service(0, CheckPlayerDistance,
            new Selector(
                new BlackboardCondition("playerDistance", Operator.IS_SMALLER_OR_EQUAL, 5f, Stops.LOWER_PRIORITY_IMMEDIATE_RESTART,
                new Sequence(
                    new Action(() => PlayHitAnimation()),
                    new Action(() => MakeHarmToEnemy()),
                    new Action(() => PlayIdleAnimation())         
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
    }
    private void PlayDeadAnimaton()
    {
        stopwatch.Stop();
        UnityEngine.Debug.Log("Time Elapsed BT: "+stopwatch.Elapsed);
        animator.SetTrigger("ToDie");
    }
    private void SinkCharacter()
    {
        timePassed += Time.deltaTime;
        transform.Translate(-Vector3.up * 0.2f * Time.deltaTime);
        (GetComponent<UnityEngine.AI.NavMeshAgent>()).enabled = false;
        (GetComponent<BoxCollider>()).enabled = false;
        (GetComponent<CharacterController>()).enabled = false;
        if (timePassed >=5) {
            characterHealth.currentHealth = characterHealth.startingHealth;
        }
    }

    private void PlayIdleAnimation()
    {
        animator.SetTrigger("ToIdle");
    }
    private void PlayHitAnimation()
    {
        animator.SetTrigger("ToAttack");
    }
    private void PlayRunAnimation()
    {
        animator.SetTrigger("ToWalk");
    }
    private void DeactivateCharacter()
    {
        timePassed = 0;
        (GetComponent<UnityEngine.AI.NavMeshAgent>()).enabled = true;
        (GetComponent<BoxCollider>()).enabled = true;
        (GetComponent<CharacterController>()).enabled = true;
        this.gameObject.SetActive(false);
    }
    private void MakeHarmToEnemy()
    {
        if (float.Equals(timeHitPassed, 0f))
        {
            playerHealt.ReciveDamage(dano);
            timeHitPassed += Time.deltaTime;
        }
        else {
            timeHitPassed += Time.deltaTime;
            if (float.Equals(timeHitPassed, 1f)) {
                timeHitPassed = 0f;
            }
        }
        
    }
    private void PursuitEnemy()
    {
        timeHitPassed = 0;
        if (navigation.isOnNavMesh)
        navigation.SetDestination(player.transform.position);
    }
    //Variables

    private void CheckCharacterHealth()
    {
        behavourTree.Blackboard["characterHealth"] = characterHealth.currentHealth;
    }
    private void CheckPlayerDistance()
    {
        behavourTree.Blackboard["playerDistance"] = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
    }
}