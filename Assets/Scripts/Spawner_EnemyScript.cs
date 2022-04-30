using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_EnemyScript : MonoBehaviour
{

    public List<GameObject> Enemies;
    private float TimeSinceLastSpawn;
    private float timeBetweenSpawn;
    [SerializeField] public Vector2 timeBetweenSpawns;
    private Vector2 randomScale = new Vector2(1.0f,2.5f);
    private float scale;

    void Start(){
        timeBetweenSpawn = Random.Range(timeBetweenSpawns.x,timeBetweenSpawns.y);
    }

    void Update()
    {
        if (TimeSinceLastSpawn > timeBetweenSpawn)
        {
            GameObject spawnedEnemy = Instantiate(Enemies[0], transform.position, transform.rotation);
            scale = Random.Range(randomScale.x,randomScale.y);
            spawnedEnemy.transform.localScale = new Vector3(scale,scale,scale);
            TimeSinceLastSpawn = 0;
            timeBetweenSpawn = Random.Range(timeBetweenSpawns.x,timeBetweenSpawns.y);
        }

        TimeSinceLastSpawn += Time.deltaTime;

    }
}
