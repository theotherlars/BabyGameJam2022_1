using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wave : MonoBehaviour {
    public string waveName;
    public float waveDuration;
    public float timeBeforeCthulhuSpawn;
    public List<WaveEnemy> enemiesThisWave = new List<WaveEnemy>();
    public static UnityEvent onWaveStart;
    public static UnityEvent onWaveEnd;
    float timeSinceWaveActive;
    public bool activeWave = false;
    float startTimer;
    float timeBeforeStart;

    private void Awake() {
        onWaveStart = new UnityEvent();
        onWaveEnd = new UnityEvent();
    }

    public void StartWave(float _timeBeforeStart){
        StartCoroutine(TimeBeforeWaveStart(_timeBeforeStart));
    }

    IEnumerator TimeBeforeWaveStart(float duration){
        yield return new WaitForSeconds(duration);
        activeWave = true;
        onWaveStart.Invoke();
    }

    private void Update() {
        if(!activeWave){return;}
        timeSinceWaveActive += Time.deltaTime;
        if(timeSinceWaveActive > timeBeforeCthulhuSpawn){
            SpawnCthulhu();
        }
        
        foreach(var enemy in enemiesThisWave){
            enemy.timeSinceSpawn += Time.deltaTime;
            if(enemy.timeSinceSpawn > enemy.timeBetweenSpawn){
                Spawner_EnemyScript.Instance.Spawn(enemy.prefab);
                enemy.timeSinceSpawn = 0;
                enemy.timeBetweenSpawn = UnityEngine.Random.Range(enemy.timeBetweenSpawns.x, enemy.timeBetweenSpawns.y);
            }
        }    

        if(timeSinceWaveActive > waveDuration && activeWave){
            activeWave = false;
            EndWave();
        }
    }

    private void SpawnCthulhu()
    {
        // Instantiate()
    }

    public void EndWave(){
        onWaveEnd.Invoke();
    }
}

[Serializable]
public class WaveEnemy{
    public GameObject prefab;
    [HideInInspector]public float timeSinceSpawn;
    public Vector2 timeBetweenSpawns;
    [HideInInspector]public float timeBetweenSpawn = 0;

    public WaveEnemy(GameObject _prefab, Vector2 _timeBetweenSpawns){
        prefab = _prefab;
        timeBetweenSpawns = _timeBetweenSpawns;
    }
}
