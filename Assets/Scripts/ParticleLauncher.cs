using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public GameObject particle; 
    public float shootTime;
    public Transform shootFrom;
    public int shootRNG;

    private float nextShootTime;
    Animator turrentAnim;

    // Start is called before the first frame update
    void Start()
    {
        turrentAnim = GetComponentInChildren<Animator>();
        nextShootTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && nextShootTime < Time.time){
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0, 10) >= shootRNG){
                
                Instantiate(particle, shootFrom.position, Quaternion.identity);
                turrentAnim.SetTrigger("shoot");
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player" && nextShootTime < Time.time){
            nextShootTime = Time.time + shootTime;
            if(Random.Range(0, 10) >= shootRNG){
                
                Instantiate(particle, shootFrom.position, Quaternion.identity);
                turrentAnim.SetTrigger("shoot");
            }
        }
    }
}
