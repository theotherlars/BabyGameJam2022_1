using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : ProjectileBase
{
    [SerializeField] float frequency;
    [SerializeField] float magnitude = 0.5f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] Vector3 from = new Vector3(0f, 0f, 45f);
    [SerializeField] Vector3 to = new Vector3(0f, 0f, -45f);
    [SerializeField] Transform childPos;
    [SerializeField] GameObject miniBomb;
    [SerializeField] int numberOfBombsToSpawn;
    [SerializeField] float spawnAllBombsWithinTime;
    Vector3 direction;
    float timerSinceLastBomb;
    int spawnedBombs = 0;

    public override void Init(){
        base.Init();
        Destroy(gameObject,timeBeforeDestroy);
    }

    private void Start() {
        Init();
        timerSinceLastBomb = (spawnAllBombsWithinTime / numberOfBombsToSpawn) / 2;
    }

    private void Update() {
        
        if(timerSinceLastBomb > spawnAllBombsWithinTime / numberOfBombsToSpawn && spawnedBombs < numberOfBombsToSpawn){
            Instantiate(miniBomb,childPos.position,Quaternion.identity);
            timerSinceLastBomb = 0;
            spawnedBombs++;
        }
        timerSinceLastBomb += Time.deltaTime;
    }

    private void FixedUpdate() {
        if(allowMovement){
            Move();
        }
    }

    private void Move()
    {   direction = transform.up;
        rb.velocity = direction * movementSpeed;
        WaveMove();
        Rotate();
    }

    private void WaveMove(){
        Vector2 tempPos = childPos.localPosition;
        tempPos.x = Mathf.Sin(Time.time * frequency) * magnitude;
        childPos.localPosition = tempPos;
    }

    private void Rotate(){
        float t = (Mathf.Sin (Time.time * rotationSpeed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        childPos.localEulerAngles = Vector3.Lerp (from, to, t);
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
