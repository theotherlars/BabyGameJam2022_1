using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_EnemyScript : MonoBehaviour
{

    public List<GameObject> Enemies;

    private float TimeSinceLastSpawn;
    private float timeBetweenSpawn;
    [SerializeField] public Vector2 timeBetweenSpawns;


    void Start(){
        timeBetweenSpawn = Random.Range(timeBetweenSpawns.x,timeBetweenSpawns.y);
    }

    void Update()
    {
        if (TimeSinceLastSpawn > timeBetweenSpawn)
        {
            GameObject spawnedEnemy = Instantiate(Enemies[0], transform.position, transform.rotation);
            TimeSinceLastSpawn = 0;
            timeBetweenSpawn = Random.Range(timeBetweenSpawns.x,timeBetweenSpawns.y);
        }

        TimeSinceLastSpawn += Time.deltaTime;

    }
}
