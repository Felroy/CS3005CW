using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    //basic movement variables
    public float maxSpeed;

    //fetching animation and knight RB2D
    Rigidbody2D myKnight;
    Animator myAnimation;
    bool facingRight;

    //jumping 
    bool grounded = false;
    float checkGround = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    //dash
    public float dashForce;
    private float DashDirection;

    //fireball
    public Transform fireLoc;
    public GameObject fire;
    float fireSpeed = 1f;
    float fireNext = 0f;
    //##
    //KnightCombat jumper;
   
    
    


    void Start()
    {
        myKnight = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        //jumper = GetComponentInParent<KnightCombat>();

        facingRight = true;       
        
    }

    void Update(){
       
                       
    }

   
    
     void FixedUpdate()
    { if(grounded && Input.GetAxis("Jump")>0){
            grounded = false;
            myAnimation.SetBool("inAir", grounded);
            myKnight.AddForce(new Vector2(0, jumpHeight));
                        
                       
        }
             
        checkIfGround();        
                  
        //change player direction
        float move = Input.GetAxis("Horizontal");
        myAnimation.SetFloat("speed", Mathf.Abs(move));
        myKnight.velocity = new Vector2(move*maxSpeed, myKnight.velocity.y);

        if(move > 0 && !facingRight){
            flip();
        } else if (move < 0 && facingRight){
            flip();
        }

        //dash function
        if(Input.GetKey(KeyCode.LeftShift) && move != 0){
            
            
            DashDirection = (int)move;
            myAnimation.SetBool("iskey", true);
            myKnight.velocity= new Vector2 (DashDirection * dashForce, myKnight.velocity.y);
            
            
        }
        else {
            myAnimation.SetBool("iskey", false);
        }

         //fireball action
        if(Input.GetKey(KeyCode.Mouse1)){
            fireRocket();
        }
                       
        
    }
    public void checkIfGround(){
        //check if knight is on the ground
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkGround, groundLayer); 
        myAnimation.SetBool("inAir", grounded);
        
    }
  
    void flip(){
        facingRight=!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x*=-1;
        transform.localScale = theScale;
    }

    void fireRocket(){
        
        if(Time.time > fireNext){
            fireNext = Time.time + fireSpeed;
            if(facingRight){
                Instantiate(fire, fireLoc.position, Quaternion.Euler(new Vector3(0,0,0)));
            }
            else if(!facingRight){
                Instantiate(fire, fireLoc.position, Quaternion.Euler(new Vector3(0,0,180f)));
            }
        }
    }
}
