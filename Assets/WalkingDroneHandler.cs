using UnityEngine;
using System.Collections;

public class WalkingDroneHandler : MonoBehaviour {
    private EnemyPoolScript walkingDronePool;
    public GameObject player;
    public int numberOfEnemys;
    public int lifeOfEnemy;
    private int numberOfEnemysCreated;
    private bool isEnable2Spawn;
    private float timeBtwSpawn;
    float time;
    // Use this for initialization
    void Start () {
        lifeOfEnemy = 0;
        walkingDronePool = GetComponent<EnemyPoolScript>();
        numberOfEnemysCreated = 0;
        isEnable2Spawn = false;
        timeBtwSpawn = 1f;
        time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (numberOfEnemysCreated < numberOfEnemys &&
            isEnable2Spawn)
        {
            if (time >= timeBtwSpawn)
            {
                createEnemyWalkingDrone();
            }

        }
    }
    public void initSpawn(int numberOfEnemys2Create) {
        isEnable2Spawn = true;
        numberOfEnemys = numberOfEnemys2Create;
    }
    void createEnemyWalkingDrone()
    {
        GameObject obj = walkingDronePool.GetPulledObject();
        if (obj != null)
        {
            obj.GetComponent<ZombieController>().player = player;
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            obj.GetComponent<EnemyHealth>().currentHealth = lifeOfEnemy;
            obj.GetComponent<EnemyHealth>().isDead = false;
            obj.SetActive(true);
        }
    }
}
