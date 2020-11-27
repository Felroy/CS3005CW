using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMovement : StateMachineBehaviour
{
    Transform knight;
    Rigidbody2D bossbody;
    BossController boss;
    bool nullCheck = false;

    public float runSpeed = 2f;
    public float meleeRange = 5f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(nullCheck == false){
        
        knight = GameObject.FindGameObjectWithTag("Player").transform;
        bossbody = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossController>();
        } 

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(knight == null)
        {
            animator.SetBool("isKnightDead", true);
        }
            
        
        else {
            animator.SetBool("isKnightDead", false);
            boss.changeDirection();                      
            Vector2 knightLoc = new Vector2(knight.position.x, bossbody.position.y);
            Vector2 targetLoc = Vector2.MoveTowards(bossbody.position, knightLoc, runSpeed * Time.fixedDeltaTime);
            bossbody.MovePosition(targetLoc); 
            if (Vector2.Distance(knight.position, bossbody.position) <  meleeRange){
            animator.SetTrigger("Attack");
            nullCheck = true;
        }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}

    
