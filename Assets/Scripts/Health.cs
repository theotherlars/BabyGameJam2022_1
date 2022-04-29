using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public UnityEvent onHealthGain;
    public UnityEvent onHealthLost;
    public UnityEvent onDeath;
    
    public void GainHealth(float amount){
        currentHealth = Mathf.Clamp(amount + currentHealth, 0, maxHealth);
        onHealthGain.Invoke();
    }

    public void LoseHealth(float amount){
        currentHealth -= amount;
        onHealthLost.Invoke();
        if(currentHealth <= 0){
            Die();
        }
    }

    public void Die(){
        onDeath.Invoke();
    }
}
