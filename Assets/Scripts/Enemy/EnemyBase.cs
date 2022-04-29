using UnityEngine;

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
        Destroy(gameObject);
    }
    
}