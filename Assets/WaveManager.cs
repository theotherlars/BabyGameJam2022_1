using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;
    public List<Wave> waves = new List<Wave>();
    public int currentWave;
    public float timeBetweenWaves;

    public static UnityEvent onWin;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        if(onWin == null){
            onWin = new UnityEvent();
        }
    }
    private void Start() {
        Wave.onWaveEnd.AddListener(NewWave);
        PlayerManager.Instance.onDeath.AddListener(StopSpawining);
        currentWave = -1;
        NewWave();
    }

    private void NewWave(){
        if(currentWave < waves.Count - 1 && !PlayerManager.Instance.dead){
            currentWave++;
            waves[currentWave].StartWave(timeBetweenWaves);
        }
        else if(!PlayerManager.Instance.dead){
            onWin.Invoke();
        }
    }

    private void StopSpawining(){
        waves[currentWave].StopSpawining();
    }
}