using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementScript : MonoBehaviour
{

    public float moveSpeed;
    //public Vector3 moveDirection;

    public GameObject PointToMoveTowards;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = transform.position;

        // enemy flies forward in a straigth line
        // transform.position = currentPos + moveDirection * Time.deltaTime; 

        // enemy flies toward specified gameObject
        transform.position = Vector2.MoveTowards(currentPos, PointToMoveTowards.transform.position, moveSpeed * Time.deltaTime);
        // constantly change facing direction
        RotateTowardsPlayer();


        //transform.rotation.SetLookRotation(PointToMoveTowards.transform.position);




    }

    private void RotateTowardsPlayer()
    {
        float offset = 270;
        Vector2 direction = PointToMoveTowards.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
