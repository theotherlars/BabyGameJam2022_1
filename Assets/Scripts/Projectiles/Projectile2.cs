using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : ProjectileBase
{
    [SerializeField]float frequency;
    [SerializeField]float magnitude = 0.5f;
    Vector3 direction;
    Vector3 pos;
    Vector2 axis;

    public override void Init(){
        base.Init();
        pos = transform.position;
        axis = transform.up;
    }

    private void Start() {
        Init();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move(){
        direction = transform.up;
        transform.position = pos + direction * Mathf.Sin(Time.time * frequency) * magnitude;
        rb.velocity = direction * movementSpeed * Time.deltaTime;
    }

}
