using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;
    public float damageRecoil;
    float nextDamage;
    
    void Start()
    {
        nextDamage = 0f;
    }
    
    //take damage when object with Player tag collides with enemy
    void OnTriggerEnter2D (Collider2D other){
         if(other.tag == "Player" && nextDamage<Time.time){
            KnightHP knightHP = other.gameObject.GetComponent<KnightHP>();
            knightHP.takeDamage(damage);
            nextDamage = Time.time + damageRate;
            
            recoil(other.transform);
        }
    }

    //take damage when object with Player tag stays in contact with enemy
    void OnTriggerStay2D (Collider2D other){
        if(other.tag == "Player" && nextDamage<Time.time){
            KnightHP knightHP = other.gameObject.GetComponent<KnightHP>();
            knightHP.takeDamage(damage);
            nextDamage = Time.time + damageRate;
            
            recoil(other.transform);
        }
    }
    
   
    //add recoil force to push back player upon taking damage
    void recoil(Transform pushedObject){
        Vector2 recoilDirection = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        recoilDirection*=damageRecoil;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(recoilDirection, ForceMode2D.Impulse);

    }
}
