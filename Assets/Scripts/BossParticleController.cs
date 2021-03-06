﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParticleController : MonoBehaviour
{
    public GameObject knio;
    
    public Transform Knight;
    public float speed = 8f;
    public float rotationSpeed = 1000f;
    private Rigidbody2D particle;
    Vector2 knightDir;
    Vector2 normKnightDir;
    bool nullCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if(nullCheck == false){
            Knight = GameObject.FindGameObjectWithTag("Player").transform;
            particle = GetComponent<Rigidbody2D>();
            knio = GameObject.FindGameObjectWithTag("Player");
        }                             
        
    }

    // Update is called once per frame
    void FixedUpdate(){       
        if (knio != null){                                    
        Vector2 direction = (Vector2)Knight.position - particle.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;

        particle.angularVelocity = -rotation * rotationSpeed;
        particle.velocity = transform.up * speed;   
    }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
        kill();  
        nullCheck = true;          
        }
        
        else {
            return;
        }

    }

    void kill(){
        Destroy(gameObject);
    }
}
