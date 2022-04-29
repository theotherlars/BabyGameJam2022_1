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
        Vector2 newVelocity;
        newVelocity.x = movementSpeed;
        newVelocity.y = magnitude * frequency * Mathf.Cos(Time.time * frequency);
        rb.velocity = newVelocity;

        // Vector2 tempPos;
        // tempPos.x = movementSpeed;
        // tempPos.y = magnitude * frequency * Mathf.Cos(Time.time * frequency);
        // transform.position = tempPos;
    }

}
