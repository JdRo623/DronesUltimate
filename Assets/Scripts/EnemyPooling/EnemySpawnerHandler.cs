using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class EnemySpawnerHandler : MonoBehaviour
{

    //  public OnNewRound OnNewRound;
    //Atributos
    public Transform[] WalkingDroneSpawnPoints;
    public Transform[] spiderDroneSpawnPoints;
    public Transform[] bossesSpawnPoints;
    public Text roundText;
    public int contadorEnemigosInicial;
    public int contadorEnemigosActual;
    public int contadorEnemigosSpawnRonda = 0;
    public int contadorEnemigosRonda;
    public int contadorEnemigosSpider;
    public int contadorEnemigosWalkers;
    public int contadorEnemigosTripod=0;
    public GameObject player;
    public int rondaActual;
    private int chosenOne;
    public int rondaAparicionTripod;
  //  public HUDHandler hudHandler;

    private AudioSource audioSource;
   // public AudioClip starRoundSound;
    //public AudioClip endRoundSound;

    private string roundTile = "Ronda";
    private string finishTile = "Completada.";
    private string initTile = "Aquí vienen";

    //Declaracion variables enemy
    float curentEnemyHealt;
    public float initialEnemyHealt;
    int cont = 0;

    private float timeBTWSpawn = 1f;
    private float timePassed = 0f;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        rondaActual = 0;
        initRound();
        contadorEnemigosActual = contadorEnemigosInicial;
        contadorEnemigosRonda = contadorEnemigosInicial;
        curentEnemyHealt = initialEnemyHealt;
    }
    void Update() {
        timePassed += Time.deltaTime;
        if (timePassed>=timeBTWSpawn) {
            Spawn();
        }
    }
    void Spawn(){

        if (contadorEnemigosTripod !=0)
        {
           contadorEnemigosTripod=
           createEnemy(findFurtherSpawnPoint(
           bossesSpawnPoints),1,true);
        }
      //  else {
            if (contadorEnemigosWalkers != 0)
            {
                contadorEnemigosWalkers=
                createEnemy(findFurtherSpawnPoint(
                 WalkingDroneSpawnPoints), contadorEnemigosWalkers,false);
            }
            if (contadorEnemigosSpider != 0)
            {
                contadorEnemigosSpider=
                createEnemy(findFurtherSpawnPoint(
                spiderDroneSpawnPoints), contadorEnemigosSpider,false);
            }

      //  }
        timePassed = 0F;
    }

    private int createEnemy(Transform spawnPoint, int numberOfEnemies2Spawn, bool boss){
        return spawnPoint.gameObject.GetComponent<SpiderDroneSpawnHandler>().createEnemy(numberOfEnemies2Spawn,boss);
    }
    double KGgenerator(double valorInicial, double seed){
        double m1 = (double)valorInicial * seed;
        return (double)Mathf.Log((float)(m1 / valorInicial));
    }
    int crecimientoExponencial(double valorInicial, double k, int rondaActual){
        double valorActual = valorInicial * (Mathf.Exp((float)(k * rondaActual)));
        return (int)(valorActual);
    }

    void initRound(){
        //  audioSource.clip = starRoundSound;
         // audioSource.Play();
        rondaActual++;
        roundText.text = rondaActual+"";
        if (rondaActual % rondaAparicionTripod == 0)
            contadorEnemigosTripod = 1;
     //   hudHandler.refreshObjectiveHUD(roundTile + " " + rondaActual + ": " + initTile);
        double k = KGgenerator(contadorEnemigosInicial, 1.2);
        contadorEnemigosWalkers = crecimientoExponencial(contadorEnemigosInicial, k, rondaActual);
        contadorEnemigosSpider = contadorEnemigosWalkers * 2;
        contadorEnemigosSpawnRonda = contadorEnemigosWalkers + contadorEnemigosSpider+contadorEnemigosTripod;
        Debug.Log("ES:" + contadorEnemigosSpider + "EW:" + contadorEnemigosWalkers + "SR:"+ contadorEnemigosSpawnRonda);
        Debug.Log(contadorEnemigosSpawnRonda);
    }

    public void OnEnemyDeath()
    {
        contadorEnemigosSpawnRonda--;
        Debug.Log("Enemigos: " + contadorEnemigosSpawnRonda);
        if (contadorEnemigosSpawnRonda == 0){
         //   hudHandler.refreshObjectiveHUD(roundTile+rondaActual+": "+finishTile);
          //  audioSource.clip = endRoundSound;
           // audioSource.Play();
            Invoke("initRound",20);
        }
    }

    public Transform findFurtherSpawnPoint(Transform[] spawnPoints) {

        Transform choosenOne = spawnPoints[0];
        float distance = 0f;
        foreach (Transform spawnPoint in spawnPoints)
        {
            float thisDistance = Vector3.Distance(spawnPoint.transform.position, player.transform.position);
            if (thisDistance>distance) {
                choosenOne = spawnPoint;
                distance = thisDistance;
            }
        }
        return choosenOne;
    }
}
    public delegate void OnEnemyDeath();


