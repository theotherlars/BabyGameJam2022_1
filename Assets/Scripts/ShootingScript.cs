using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public List<ActiveWeapon> currentWeapons = new List<ActiveWeapon>();

    [Header("Bullets")]
    public GameObject bulletToSpawn;

    float timeSinceLastShot;
    [SerializeField] float coolDownOnShot;


    [Header("TogglesToActivateCanons")]
    [SerializeField] bool canFireCanon;

    [Header("TogglesToActivateCanons")]
    public string firingKey;


    // Update is called once per frame
    void Update()
    {

        if (timeSinceLastShot > coolDownOnShot)
        {
            if (Input.GetButtonDown(firingKey))
            {
                if (canFireCanon == true)
                {
                    Instantiate(bulletToSpawn, transform.position, transform.rotation);
                    timeSinceLastShot = 0;
                }
            }
        }

        timeSinceLastShot += Time.deltaTime;
    }
}

[System.Serializable]
public class ActiveWeapon{
    int weaponInt;
    KeyCode key;

    public ActiveWeapon(int _weaponInt, KeyCode _key){
        weaponInt = _weaponInt;
        key = _key;
    }
}