using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody2D myRB;  
    public float fireballSpeed;

    void Awake(){        
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0){
            myRB.AddForce(new Vector2(-1, 0)* fireballSpeed, ForceMode2D.Impulse);
        } else {
            myRB.AddForce(new Vector2(1, 0)* fireballSpeed, ForceMode2D.Impulse);
        }
    }
    public void removeForce(){
        myRB.velocity = new Vector2(0, 0);
    }
}
