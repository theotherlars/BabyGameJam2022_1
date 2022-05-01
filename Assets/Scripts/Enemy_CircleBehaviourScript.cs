using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_CircleBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float Radius = 0.9f;

    [Header("Variables controlling enemy moving inwards")]
    [SerializeField] float timeBetweenEncomposaing;
    [SerializeField] float radiusDecreaseValue;
    [SerializeField] GameObject bullet;



    GameObject playerObject;


    float TimeSinceLastRadiusSubtraction;

    private Vector2 _centre;
    private float _angle;
    public float offset;

    private void Start()
    {
        _centre = transform.position;
        playerObject = GameObject.Find("Player (Planet)");
        StartCoroutine("EnemyShoot");
    }

    private void Update()
    {

        _angle += moveSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;


        if (TimeSinceLastRadiusSubtraction > timeBetweenEncomposaing)
        {
            Radius = Radius - radiusDecreaseValue;
            TimeSinceLastRadiusSubtraction = 0;
        }

        TimeSinceLastRadiusSubtraction += Time.deltaTime;

        if(PlayerManager.Instance.currentHealth > 0){
            RotateTowardsPlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        
        Vector2 direction = playerObject.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(2);
        Instantiate(bullet, transform.position, transform.rotation);
        StartCoroutine("EnemyShoot");

    }

}
