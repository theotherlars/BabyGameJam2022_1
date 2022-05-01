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
    public bool dead = false;

    private void Awake() {
        pointA = transform.position;
        pointB = pointA + new Vector3(40,0,0);
    }
    void Start()
    {
        
        StartCoroutine("MoveDownAfterCountDown");
        
    }

    void Update()
    {
        //PingPong between 0 and 1
        if(!dead){
            float time = Mathf.PingPong(Time.time * speed, 1);
            transform.position = Vector3.Lerp(pointA, pointB, time);
        }
        else{
            transform.position += new Vector3(speed * Time.deltaTime,0,0);
            transform.RotateAround(transform.position,Vector3.forward,5 * Time.deltaTime);
        }
    }


    IEnumerator MoveDownAfterCountDown()
    {
        yield return new WaitForSeconds(timeBetweenSubtractingDistance);
        pointA.y = pointA.y - 1;
        pointB.y = pointB.y - 1;
        StartCoroutine("MoveDownAfterCountDown");
    }

    public void Dead(){
        dead = true;
    }
}
