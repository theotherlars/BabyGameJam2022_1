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
        // transform.position = currentPos + moveDirection * Time.deltaTime; 


        transform.position = Vector2.MoveTowards(currentPos, PointToMoveTowards.transform.position, moveSpeed * Time.deltaTime);

    }
}
