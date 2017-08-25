using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateEnemySpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject[] minionEnemies;
    public GameObject[] bossEnemies;

    public int contadorEnemigosInicial;
    public int contadorEnemigosActual;
    public int contadorEnemigosSpawnRonda = 0;
    public int contadorEnemigosRonda;
    public int contadorEnemigosSpider;
    public int contadorEnemigosWalkers;
    public int contadorEnemigosTripod = 0;
    public GameObject player;
    public int rondaActual;
    public int bossRound;
    public HUDHandler hudHandler;

    private AudioSource audioSource;
    public AudioClip starRoundSound;
    public AudioClip endRoundSound;

    private string roundTile = "Ronda";
    private string finishTile = "Completada.";
    private string initTile = "Aquí vienen";

    //Declaracion variables enemy
    float curentEnemyHealt;
    public float initialEnemyHealt;
    int cont = 0;

    private float timeBTWSpawn = 1f;
    private float timePassed = 0f;

    private Transform chosenOne;
    // Use this for initialization
    void Start()
    {
      //  audioSource = GetComponent<AudioSource>();
        rondaActual = 0;
        initRound();
        contadorEnemigosActual = contadorEnemigosInicial;
        contadorEnemigosRonda = contadorEnemigosInicial;
        curentEnemyHealt = initialEnemyHealt;
    }
 

    private int createEnemy(Transform spawnPoint, int numberOfEnemies2Spawn)
    {
        return spawnPoint.gameObject.GetComponent<SpiderDroneSpawnHandler>().createEnemy(numberOfEnemies2Spawn,false);
    }

    double KGgenerator(double valorInicial, double seed)
    {
        double m1 = (double)valorInicial * seed;
        return (double)Mathf.Log((float)(m1 / valorInicial));
    }
    int crecimientoExponencial(double valorInicial, double k, int rondaActual)
    {
        double valorActual = valorInicial * (Mathf.Exp((float)(k * rondaActual)));
        return (int)(valorActual);
    }

    void initRound()
    {
      //  audioSource.clip = starRoundSound;
       // audioSource.Play();
        rondaActual++;
        if (rondaActual % bossRound == 0)
            contadorEnemigosTripod = 1;
        //hudHandler.refreshObjectiveHUD(roundTile + " " + rondaActual + ": " + initTile);
        double k = KGgenerator(contadorEnemigosInicial, 1.2);
        contadorEnemigosWalkers = crecimientoExponencial(contadorEnemigosInicial, k, rondaActual);
        contadorEnemigosSpider = contadorEnemigosWalkers * 2;
        contadorEnemigosSpawnRonda = contadorEnemigosWalkers + contadorEnemigosSpider + contadorEnemigosTripod;
        Debug.Log("ES:" + contadorEnemigosSpider + "EW:" + contadorEnemigosWalkers + "SR:" + contadorEnemigosSpawnRonda);
        Debug.Log(contadorEnemigosSpawnRonda);
    }

    public void OnEnemyDeath()
    {
        contadorEnemigosSpawnRonda--;
        Debug.Log("Enemigos: " + contadorEnemigosSpawnRonda);
        if (contadorEnemigosSpawnRonda == 0)
        {
            hudHandler.refreshObjectiveHUD(roundTile + rondaActual + ": " + finishTile);

            //audioSource.clip = endRoundSound;
            //audioSource.Play();
            Invoke("initRound", 20);
        }
    }
    public Transform spawnPointChooser() {
        chosenOne = spawnPoints[ Random.Range(0,spawnPoints.Length)];
        return chosenOne;
    }

}
