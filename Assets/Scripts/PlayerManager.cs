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
    public int IngameCurrency;  // currency used to purchase upgrades
    public UnityEvent onNewSlot;
    Animator anim; 
    public int killsBefore2Slots = 40;
    public int killsBefore3Slots = 100;
    int kills;
    bool doOnce = true;
    bool doOnce2 = true;
    bool doOnce3 = true;

    public bool dead = false;

    [SerializeField]List<GameObject>shipParts = new List<GameObject>();
    [SerializeField] GameObject explosion;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();
        Application.targetFrameRate = 60;
    }
    private void Start() {
        EnemyBase.onDied.AddListener(IncreaseCurrencyCount);
    }

    private void Update() {
        if(dead){return;}

        HandleWeaponInput();
        HandleShotTimes();

        if(kills == killsBefore2Slots && doOnce){
            doOnce = false;
            NewSlot();
        }

        if(kills == killsBefore3Slots && doOnce2){
            doOnce2 = false;
            NewSlot();
        }
    }


    private void HandleShotTimes(){
        timeSinceLastShot[0] += Time.deltaTime;
        timeSinceLastShot[1] += Time.deltaTime;
        timeSinceLastShot[2] += Time.deltaTime;
    }

    private void HandleWeaponInput()
    {
        if(slotsAvailable >= 1){
            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.J)){
                if(timeSinceLastShot[0] > allWeapons[activeWeapons[0]].timeBetweenShots){
                    Shoot(activeWeapons[0]);
                    timeSinceLastShot[0] = 0;
                }
            }
        }
        
        if(slotsAvailable >= 2){
            if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.K)){
                if(timeSinceLastShot[1] > allWeapons[activeWeapons[1]].timeBetweenShots){
                    Shoot(activeWeapons[1]);
                    timeSinceLastShot[1] = 0;
                }
            }
        }
        
        if(slotsAvailable >= 3){
            if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.L)){
                if(timeSinceLastShot[2] > allWeapons[activeWeapons[2]].timeBetweenShots){
                    Shoot(activeWeapons[2]);
                    timeSinceLastShot[2] = 0;
                }
            }
        }
    }
    
    public void IncreaseCurrencyCount(int amount){
        IngameCurrency = IngameCurrency + amount;
        kills++;
    }

    public void NewSlot(){
        if(slotsAvailable + 1 <= maxSlots){
            slotsAvailable++;
            switch(slotsAvailable){
                case 2 : {
                    anim.Play("spaceship_powerup_right",0);
                    break;
                }
                case 3 : {
                    anim.Play("spaceship_powerup_left",0);
                    break;
                }
            }
            onNewSlot.Invoke();
        }
    }

    public void Shake(){
        CameraShakeScript.Instance.CameraShake();
        if(currentHealth == 0){
            Died();
        }
    }

    public void Shoot(int weaponIndex){
        Instantiate(allWeapons[weaponIndex].prefab, shootingPos.position,transform.rotation);
    }

    public void SetActiveWeapon(int activeWeaponIndex, int weaponIndex){
        activeWeapons[activeWeaponIndex] = weaponIndex;
    }

    public void Died(){
        dead = true;
        foreach(var part in shipParts){
            GameObject newPart = Instantiate(part, transform.position,Quaternion.identity);
            if(newPart.TryGetComponent(out Rigidbody2D rb)){
                if(UnityEngine.Random.value > 0.5){
                    rb.AddForce(Vector2.left + Vector2.up * 3, ForceMode2D.Impulse);
                }else{
                    rb.AddForce(Vector2.right + Vector2.down * 3, ForceMode2D.Impulse);
                }
            }
        }
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
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
    public Sprite weaponBackground;
    public Sprite weaponIcon;
    public bool available = false;
    public int cost;

    public Weapon(GameObject _prefab, int _index, float _timeBetweenShots, Sprite _weaponBackground, Sprite _weaponIcon, bool _available, int _cost){
        prefab = _prefab;
        index = _index;
        timeBetweenShots = _timeBetweenShots;
        weaponBackground = _weaponBackground;
        weaponIcon = _weaponIcon;
        available = _available;
        cost = _cost;
    }
}