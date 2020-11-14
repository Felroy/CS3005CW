using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public float fireDamage;
    ProjectileController myPC;

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("basicEnemy")){
            myPC.removeForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy"){
                enemyHP hurtEnemy = other.gameObject.GetComponent<enemyHP>();
                hurtEnemy.takeDamage(fireDamage);
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
        }
    }
}
