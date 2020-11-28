using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossParticleController : MonoBehaviour
{
    public GameObject knio;
    
    public Transform Knight;
    public float speed = 8f;
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
        knightDir = (Knight.transform.position - transform.position);
        normKnightDir = knightDir.normalized * speed;
        particle.velocity = new Vector2 (normKnightDir.x, normKnightDir.y); 
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
