using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour
{

    
    [SerializeField]Vector2 moveSpeeds;
    float moveSpeed;
    //public Vector3 moveDirection;

    public GameObject PointToMoveTowards;
    public Transform childPos;

    [SerializeField]Vector2 frequencyFromTo;
    [SerializeField]Vector2 magnitudeFromTo;
    float frequency;
    float magnitude;



    // Start is called before the first frame update
    void Start(){
        moveSpeed = Random.Range(moveSpeeds.x, moveSpeeds.y);
        frequency = Random.Range(frequencyFromTo.x, frequencyFromTo.y);
        magnitude = Random.Range(magnitudeFromTo.x, magnitudeFromTo.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;

        // enemy flies toward specified gameObject
        transform.position = Vector2.MoveTowards(currentPos, PointToMoveTowards.transform.position, moveSpeed * Time.deltaTime);
        // constantly change facing direction
        // RotateTowardsPlayer();
        // WaveMove();
    }

    private void RotateTowardsPlayer()
    {
        float offset = 270;
        Vector2 direction = PointToMoveTowards.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void WaveMove(){
        Vector2 tempPos = childPos.localPosition;
        tempPos.x = Mathf.Sin(Time.time * frequency) * magnitude;
        childPos.localPosition = tempPos;
    }
}
