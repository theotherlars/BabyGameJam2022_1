using UnityEngine;

public class PlayerManager : Health {
    
    private void Awake() {
        currentHealth = maxHealth;
    }

    public void Shake(){
        CameraShakeScript.Instance.CameraShake();
    }

    public void PlayerDied(){
        
    }   
}