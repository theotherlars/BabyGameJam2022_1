using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningNPCScript : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 0.1f;
    [SerializeField] float Radius = 0.9f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
    }
}
