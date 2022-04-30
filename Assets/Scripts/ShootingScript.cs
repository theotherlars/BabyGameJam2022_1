using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

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
