using NPBehave;
using UnityEngine;
using UnityEngine.AI;

public class SoilderBT : MonoBehaviour
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
    // Use this for initialization
    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerHealt = player.GetComponent<PLayerHealt>();
        characterHealth = GetComponent<EnemyHealth>();
        animator.Play("Walking");

        behavourTree = new Root(
            //First
            new Service(0, CheckCharacterHealth,
            new Selector(
                new BlackboardCondition("characterHealth", Operator.IS_SMALLER_OR_EQUAL, 0, Stops.IMMEDIATE_RESTART,
                new Sequence(
                     new Action(() => PlayDeadAnimaton()),
                     new Action((bool shouldCancel) => {
                         if (timePassed < 5)
                         {
                             SinkCharacter();
                             return Action.Result.PROGRESS;
                         }
                         else
                         {
                             DeactivateCharacter();
                             timePassed = 0;
                             return Action.Result.FAILED;
                         }
                     }),
                     new WaitUntilStopped())),
            //Second leaf
            new Service(0, CheckPlayerDistance,
            new Selector(
                new BlackboardCondition("playerDistance", Operator.IS_SMALLER_OR_EQUAL, 5f, Stops.IMMEDIATE_RESTART,
                new Sequence(
                    new Action(() => PlayHitAnimation()),
                    new Action(() => MakeHarmToEnemy()),
                    new Action(() => PlayIdleAnimation()),
                    new Action((bool shouldCancel) =>
                    {
                        if (timePassed < 1.5)
                        {
                            Rest();
                            return Action.Result.PROGRESS;
                        }
                        else
                        {
                            timePassed = 0;
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


    //Tree
    
    //Actions

    private void PlayDeadAnimaton()
    {
        animator.SetTrigger("ToDie");
    }
    private void SinkCharacter()
    {
        timePassed += Time.deltaTime;
        transform.Translate(-Vector3.up * 0.2f * Time.deltaTime);
        (GetComponent<UnityEngine.AI.NavMeshAgent>()).enabled = false;
        (GetComponent<BoxCollider>()).enabled = false;
        (GetComponent<CharacterController>()).enabled = false;
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
        playerHealt.ReciveDamage(dano);
    }
    private void Rest()
    {
        timePassed = Time.deltaTime;
    }
    private void PursuitEnemy()
    {
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