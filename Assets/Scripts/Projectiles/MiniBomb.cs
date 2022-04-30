using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MiniBomb : Projectile2
{
    [SerializeField] float timeBeforeExplode;
    [SerializeField] float explosionRadius;
    [SerializeField] Light2D light2D; 
    [SerializeField] Color redLight;
    [SerializeField] Color greenLight;
    [SerializeField] int blinkCount;
    float timeSinceBlink; 
    float timeSinceSpawn;
    int blinks;

    private void Start() {
        light2D.color = greenLight;
    }

    private void Update() {
        if(timeSinceSpawn > timeBeforeExplode){
            Explode();
        }
        if(timeSinceBlink > (timeBeforeExplode / blinkCount) && blinks <= blinkCount){
            if(blinks == blinkCount -2){
                light2D.color = redLight;
            } 
            StartCoroutine(Blink(timeBeforeExplode / blinkCount));
            blinks++;
            timeSinceBlink = 0;
        }
        
        timeSinceBlink += Time.deltaTime;
        timeSinceSpawn += Time.deltaTime;
    }

    IEnumerator Blink(float duration){
        light2D.intensity = 0;
        float timer = 0;
        while(timer < duration / 2){
            light2D.intensity = Mathf.Lerp(light2D.intensity,3,duration/2 * Time.deltaTime);
            yield return null;
            timer += Time.deltaTime;
        }
        timer = 0;
        while(timer < duration / 2){
            light2D.intensity = Mathf.Lerp(light2D.intensity,0,duration/2 * Time.deltaTime);
            yield return null;
            timer += Time.deltaTime;
        }
        light2D.intensity = 0;
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
}
