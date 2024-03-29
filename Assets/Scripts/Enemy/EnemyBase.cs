using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
[System.Serializable]
public class MyDeathEvent : UnityEvent<int>
{

}

public class EnemyBase : Health {

    public static MyDeathEvent onDied = new MyDeathEvent();
    [SerializeField]int onDiedCurrency = 1;
    [SerializeField]ParticleSystem particlesOnDeath;
    [SerializeField]List<AudioClip> explosionClips = new List<AudioClip>();


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
        onDied.Invoke(onDiedCurrency);
        if(particlesOnDeath){
            
            Instantiate(particlesOnDeath, transform.position,Quaternion.identity);
            
            Destroy(gameObject);

        }
        if(gameObject.TryGetComponent(out Animator anim)){
            anim.SetTrigger("Dead");
        }
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