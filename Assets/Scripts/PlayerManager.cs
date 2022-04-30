using UnityEngine;


public class PlayerManager : Health
{


    public int IngameCurrency;  // currency used to purchase upgrades

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Shake()
    {
        CameraShakeScript.Instance.CameraShake();
    }

    public void PlayerDied()
    {

    }

    public void IncreaseCurrencyCount(int amount)
    {
        IngameCurrency = IngameCurrency + amount;
    }
}