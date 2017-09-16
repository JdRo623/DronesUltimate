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
    AudioSource audioSource;
    public GameObject render;
    CharacterController enemy;
    private Vector3 movementVector;
    private float gravity = 40;
    public ParticleSystem hitParticles;
    public int firedamage;
    public int knifedamage;

    void OnEnable() {
        isDead = false;
        currentHealth = startingHealth;
    }
    void Awake(){
		animator = GetComponent <Animator> ();
        audioSource = GetComponent<AudioSource>();
       // hitParticles = GetComponent<ParticleSystem>();
        //Declaracion observers
        try {
            EnemySpawnerHandler enemySpawnerHandler = FindObjectOfType<EnemySpawnerHandler>();
            OnEnemyDeath = enemySpawnerHandler.OnEnemyDeath;
        }
        catch (Exception e) {      
            Debug.Log("controlado");
        }
        
    }
	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
        //hitParticles.transform.position = hitPoint;
       // hitParticles.Play();
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	void Death ()
	{
        if (!isDead) {
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