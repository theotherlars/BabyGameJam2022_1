using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{


    public float playerTurnSpeed;

    void Update()
    {
        PlayerRotate();

        Fire();
    }

    private static void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Firing");
        }
    }

    private void PlayerRotate()
    {
        Vector3 currentPos = transform.eulerAngles;
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            transform.eulerAngles = currentPos + new Vector3(0, 0, -playerTurnSpeed) * Time.deltaTime;
        }
        else if (horizontalInput < 0)
        {
            transform.eulerAngles = currentPos + new Vector3(0, 0, playerTurnSpeed) * Time.deltaTime;
        }
    }
}
