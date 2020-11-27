using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject knio;
    
    public Transform Knight;
    public float speed = 3f;
    public float rotationSpeed = 1000f;
    private Rigidbody2D particle;
    Vector2 knightDir;
    Vector2 normKnightDir;        
    
    void Start()
    {
        //find components
        Knight = GameObject.FindGameObjectWithTag("Player").transform;
        particle = GetComponent<Rigidbody2D>();
        knio = GameObject.FindGameObjectWithTag("Player"); 

        //set velocity to particles
        knightDir = (Knight.transform.position - transform.position);
        normKnightDir = knightDir.normalized * speed;
        particle.velocity = new Vector2 (normKnightDir.x, normKnightDir.y);
    }  
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
        kill();            
        }
        
        else {
            return;
        }

    }

    void kill(){
        Destroy(gameObject);
    }
}
