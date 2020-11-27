using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentController : MonoBehaviour
{
    public GameObject turret;

    //flip function variables
    
    bool canFlip = true;
    bool facingRight;
   
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(facingRight && other.transform.position.x < transform.position.x){
                flipFaceDir();

            }
            else if(!facingRight && other.transform.position.x > transform.position.x){
                flipFaceDir();
            }
            canFlip = false;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            canFlip = true;                        
        }
    }

    void flipFaceDir(){
        if(!canFlip) {
            return;
        }
        float facingX = turret.transform.localScale.x;
        facingX *= -1f;

        turret.transform.localScale = new Vector3(facingX, turret.transform.localScale.y, turret.transform.localScale.z);
        facingRight =! facingRight;
    }


}
