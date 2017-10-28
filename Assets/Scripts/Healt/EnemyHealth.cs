using UnityEngine;
using System;
public class EnemyHealth : MonoBehaviour
{
    //Observers
    public OnEnemyDeath OnEnemyDeath;

    public int startingHealth = 100;            
	public int currentHealth;                  
	public int scoreValue = 10;                 
	public AudioClip deathClip;                 
	Animator animator;                              
	CapsuleCollider capsuleCollider;          
	public bool isDead;
    public bool isStateMachines;
    AudioSource audioSource;
    public GameObject render;
    
    CharacterController enemy;
    private Vector3 movementVector;
    private float gravity = 40;
    public int firedamage;
    public int knifedamage;
    private ParticleSystem blood;

    void OnEnable() {
        isDead = false;
        currentHealth = startingHealth;
    }
    void Awake(){
		animator = GetComponent <Animator> ();
        audioSource = GetComponent<AudioSource>();
        blood = GetComponent<ParticleSystem>();
       // hitParticles = GetComponent<ParticleSystem>();
        //Declaracion observers
        try {
            //Change make this an option
            if (isStateMachines)
            {
                EnemySpawnerHandler enemySpawnerHandler = FindObjectOfType<EnemySpawnerHandler>();
                OnEnemyDeath = enemySpawnerHandler.OnEnemyDeath;
            }
            else {
                BTEnemySpawnerHandler enemySpawnerHandler = FindObjectOfType<BTEnemySpawnerHandler>();
                OnEnemyDeath = enemySpawnerHandler.OnEnemyDeath;
            }
            
           
        }
        catch (Exception e) {      
            Debug.Log("controlado");
        }
        
    }
	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
       // hitParticles.transform.position = hitPoint;
        blood.Play();
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	void Death ()
	{
        if (!isDead) {
            blood.Stop();
            OnEnemyDeath();
        }
        isDead = true;
    }

    void OnTriggerStay(Collider Col)
    {
        if (Col.tag == "Fire")
        {// if robot in fire 
            currentHealth -= firedamage;
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void OnTriggerEnter(Collider Col2)
    {
        if (Col2.tag == "Knife")
        { // if hit knife 
            currentHealth -= knifedamage;
        }
        if (currentHealth <= 0)
        {
            Death();
        }
    }
}