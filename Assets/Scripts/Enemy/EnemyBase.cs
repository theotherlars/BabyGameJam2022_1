using UnityEngine;
using System;

public class EnemyBase : Health {


    private void OnEnable() {
        onDeath.AddListener(Death);
    }

    private void OnDisable() {
        onDeath.RemoveListener(Death);
    }

    private void Start() {
        currentHealth = maxHealth;
    }


    void Death(){
        // broadcast death
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(other.gameObject.TryGetComponent(out PlayerManager pm)){
                pm.LoseHealth(1);
                Destroy(gameObject);
            }
        }
    }
    
}