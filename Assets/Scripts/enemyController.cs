using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject enemyBody;
    public float enemySpeed;
    Animator enemyAnim;

    //enemy facing direction
    bool canFlip = true;
    bool facingRight = false;
    private float flipRate = 2f;
    private float nextFlip = 0f;

    //enemy attacking
    Rigidbody2D enemyRB;
    public float chargeTime;
    private float chargeTimeStart;
    bool isCharging;
    

    void Start()
    {
        enemyAnim = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > nextFlip){
            if(Random.Range(0, 10) >= 5){
                flipFaceDir();
            }
            nextFlip = Time.time + flipRate;
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(facingRight && other.transform.position.x < transform.position.x){
                flipFaceDir();

            }
            else if(!facingRight && other.transform.position.x > transform.position.x){
                flipFaceDir();
            }
            canFlip = false;
            isCharging = true;
            chargeTimeStart = Time.time + chargeTime;
        }
    }    

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            canFlip = true;
            isCharging = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnim.SetBool("isAttacking", isCharging);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(chargeTimeStart < Time.time){
                if(!facingRight){
                    flipFaceDir();
                    enemyRB.AddForce(new Vector2(-1,0)*enemySpeed);
                }
                else {
                    flipFaceDir();
                    enemyRB.AddForce(new Vector2(1,0)*enemySpeed);

                }
                enemyAnim.SetBool("isAttacking", isCharging);
            }
        }
    }

    void flipFaceDir(){
        if(!canFlip) {
            return;
        }
        float facingX = enemyBody.transform.localScale.x;
        facingX *= -1f;

        enemyBody.transform.localScale = new Vector3(facingX, enemyBody.transform.localScale.y, enemyBody.transform.localScale.z);
        facingRight =! facingRight;
    }
}
