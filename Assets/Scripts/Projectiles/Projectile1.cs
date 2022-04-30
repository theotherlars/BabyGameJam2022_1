using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : ProjectileBase
{
    Vector2 direction;
    
    public override void Init(){
        base.Init();
        Destroy(gameObject,timeBeforeDestroy);
    }

    private void Start() {
        Init();
    }

    private void FixedUpdate() {
        if(allowMovement){
            Move();
        }
    }

    private void Move(){
        direction = transform.up;
        rb.velocity = direction * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            if(other.gameObject.TryGetComponent(out EnemyBase enemy)){
                DealDamage(enemy);
                onHit.Invoke();
                Instantiate(explosion,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

}
