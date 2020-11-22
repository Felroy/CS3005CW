using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    //public GameObject particle1;
    public Transform Knight;
    public float speed = 3f;
    public float rotationSpeed = 1000f;
    private Rigidbody2D particle;
    // Start is called before the first frame update
    void Start()
    {
        Knight = GameObject.FindGameObjectWithTag("Player").transform;
        particle = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)Knight.position - particle.position;
        direction.Normalize();
        float rotation = Vector3.Cross(direction, transform.up).z;

        particle.angularVelocity = -rotation * rotationSpeed;
        particle.velocity = transform.up * speed;
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            kill();
        }

    }

    void kill(){
        Destroy(gameObject);
    }
}
