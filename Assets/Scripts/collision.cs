﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour{
    public GameObject explosionEffect;
    public float fireDamage;
    ProjectileController myPC;
    
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();        
    }

    //collision functions for fireball
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("basicEnemy")){
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy"){
                enemyHP hurtEnemy = other.gameObject.GetComponent<enemyHP>();
                hurtEnemy.takeDamage(fireDamage);
            }
            else if(other.tag == "Boss"){
                BossHP hurtBoss = other.gameObject.GetComponent<BossHP>();
                hurtBoss.takeDamageBoss(fireDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("basicEnemy")){
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy"){
                enemyHP hurtEnemy = other.gameObject.GetComponent<enemyHP>();
                hurtEnemy.takeDamage(fireDamage);
            }
            else if(other.tag == "Boss"){
                BossHP hurtBoss = other.gameObject.GetComponent<BossHP>();
                hurtBoss.takeDamageBoss(fireDamage);
            }
        }
    }
}
