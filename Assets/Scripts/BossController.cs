using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //public bool facingRight = false;
    public bool canFlip = false;
    public Transform knight;

    public void changeDirection(){
        if (transform.position.x > knight.position.x && canFlip){
            flipDir();
            canFlip = false;            
        }
        
        else if (transform.position.x < knight.position.x && !canFlip == true){
            flipDir();
            canFlip = true;            
        }
    } 

    void flipDir(){
        Vector3 facingX = transform.localScale;
        facingX.z *= -1f;
        transform.localScale = facingX; 
        transform.Rotate(0f, 180f, 0f);       
        }
}

