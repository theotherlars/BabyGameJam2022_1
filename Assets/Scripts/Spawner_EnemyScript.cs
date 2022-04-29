using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_EnemyScript : MonoBehaviour
{

    public List<GameObject> Enemies;

    private float TimeSinceLastSpawn;
    [SerializeField] public float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeSinceLastSpawn > timeBetweenSpawns)
        {
            GameObject spawnedEnemy = Instantiate(Enemies[0], transform.position, transform.rotation);
        }

        TimeSinceLastSpawn += Time.deltaTime;

    }
}
