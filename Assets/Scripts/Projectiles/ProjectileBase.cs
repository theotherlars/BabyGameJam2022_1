using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileBase : MonoBehaviour
{
    public float movementSpeed;
    public bool allowMovement;
    [SerializeField]bool randomDamage;
    [SerializeField]List<AudioClip> explosionClips = new List<AudioClip>();
    
    [Tooltip("X = minDamage, Y = maxDamage")]
    [SerializeField]Vector2 damage;
    [HideInInspector] public float timeBeforeDestroy = 5f;
    [HideInInspector] public Rigidbody2D rb;
    public GameObject explosion;
    public UnityEvent onHit;

    public virtual void Init(){
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void DealDamage(EnemyBase enemy){
        float damageToApply = damage.x;
        int index  = Random.Range(0,2);
        AudioManager.Instance.audioSource.PlayOneShot(explosionClips[index]);
        if(randomDamage){
            damageToApply = Random.Range(damage.x, damage.y);
        }
        enemy.LoseHealth(damageToApply);
    }
}