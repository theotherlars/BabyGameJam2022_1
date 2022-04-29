using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationScript : MonoBehaviour
{

    [SerializeField] float turnRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0,0, turnRate)  * Time.deltaTime;
    }
}
