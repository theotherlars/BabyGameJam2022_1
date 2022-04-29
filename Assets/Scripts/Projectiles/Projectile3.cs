using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3 : ProjectileBase
{
    [Header("Projectile 3 Specific:")]
    [SerializeField]float timeBeforeExplode;
    [SerializeField]float explosionRadius;
    Vector2 direction;
    float timer;
    
    public override void Init(){
        base.Init();
        Destroy(gameObject,timeBeforeDestroy);
    }

    private void Start() {
        Init();
    }

    private void Update() {
        if(timer > timeBeforeExplode){
            Explode();
        }
        timer += Time.deltaTime;
    }

    private void FixedUpdate() {
        Move();
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

    private void Explode(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,explosionRadius,Vector2.zero);
        if(hits.Length > 0){
            foreach(var hit in hits){
                if(hit.transform.TryGetComponent(out EnemyBase enemy)){
                    DealDamage(enemy);
                    onHit.Invoke();
                }
            }
        }
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(transform.position,explosionRadius);
    }
}
