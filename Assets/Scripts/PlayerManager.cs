using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.Events;

public class PlayerManager : Health {
    
    public static PlayerManager Instance;
    [SerializeField] Transform shootingPos;
    public List<Weapon> allWeapons = new List<Weapon>();
    public int[] activeWeapons = new int[3] {0,0,0};
    public int slotsAvailable = 1;
    public int maxSlots = 3;
    float[] timeSinceLastShot = new float[3]{0,0,0};

    public UnityEvent onNewSlot;

    public int IngameCurrency;  // currency used to purchase upgrades

    public void IncreaseCurrencyCount(int amount)
    {
        IngameCurrency = IngameCurrency + amount;
    }


    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
        currentHealth = maxHealth;
    }

    private void Update() {
        HandleWeaponInput();
        HandleShotTimes();
    }

    private void HandleShotTimes()
    {
        timeSinceLastShot[0] += Time.deltaTime;
        timeSinceLastShot[1] += Time.deltaTime;
        timeSinceLastShot[2] += Time.deltaTime;
    }

    private void HandleWeaponInput()
    {
        if(slotsAvailable >= 1){
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                if(timeSinceLastShot[0] > allWeapons[activeWeapons[0]].timeBetweenShots){
                    Shoot(activeWeapons[0]);
                    timeSinceLastShot[0] = 0;
                }
            }
        }
        
        if(slotsAvailable >= 2){
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                if(timeSinceLastShot[1] > allWeapons[activeWeapons[1]].timeBetweenShots){
                    Shoot(activeWeapons[1]);
                    timeSinceLastShot[1] = 0;
                }
            }
        }
        
        if(slotsAvailable >= 3){
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                if(timeSinceLastShot[2] > allWeapons[activeWeapons[2]].timeBetweenShots){
                    Shoot(activeWeapons[2]);
                    timeSinceLastShot[2] = 0;
                }
            }
        }
    }

    public void NewSlot(){
        if(slotsAvailable + 1 <= maxSlots){
            slotsAvailable++;
            onNewSlot.Invoke();
        }
    }

    public void Shake(){
        CameraShakeScript.Instance.CameraShake();
    }

    public void Shoot(int weaponIndex){
        Instantiate(allWeapons[weaponIndex].prefab, shootingPos.position,transform.rotation);
    }

    public void SetActiveWeapon(int activeWeaponIndex, int weaponIndex){
        activeWeapons[activeWeaponIndex] = weaponIndex;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            if(other.gameObject.TryGetComponent(out EnemyBase enemy)){
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            if(other.gameObject.TryGetComponent(out EnemyBase enemy)){
                Destroy(other.gameObject);
            }
        }
    }
}


[Serializable]
public class Weapon{
    public GameObject prefab;
    public int index;
    public float timeBetweenShots;

    public Weapon(GameObject _prefab, int _index, float _timeBetweenShots){
        prefab = _prefab;
        index = _index;
        timeBetweenShots = _timeBetweenShots;
    }
}