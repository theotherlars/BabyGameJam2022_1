using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportngEnemyScript : MonoBehaviour
{


    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        StartCoroutine("RandomMovement");

    }

    IEnumerator RandomMovement()
    {
        yield return new WaitForSeconds(3);
        transform.position = new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), 0);
        StartCoroutine("RandomMovement");
    }


    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bullet, transform.position, transform.rotation);


    }



}
