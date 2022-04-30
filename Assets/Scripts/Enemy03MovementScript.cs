using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy03MovementScript : MonoBehaviour
{



    [SerializeField] float speed;
    [SerializeField] float subtractionDistance;
    [SerializeField] float timeBetweenSubtractingDistance;
    [SerializeField] Vector3 pointA;
    [SerializeField] Vector3 pointB;

    void Start()
    {
        StartCoroutine("MoveDownAfterCountDown");
    }

    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);

    }


    IEnumerator MoveDownAfterCountDown()
    {
        yield return new WaitForSeconds(timeBetweenSubtractingDistance);
        Debug.Log("Pew pew");
        pointA.y = pointA.y - 1;
        pointB.y = pointB.y - 1;
        StartCoroutine("MoveDownAfterCountDown");

    }

}
