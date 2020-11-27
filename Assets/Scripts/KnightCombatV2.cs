using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCombatV2 : MonoBehaviour
{
    //attack variables
    public Animator animation1;
    public Transform attackLoc;
    public float attackRange = 0.5f;
    public float attackDamage;
    public LayerMask enemy;
    
    void Update()
    {
        attackCombat();
    }   
    
    //attack when mouse0/left click is clicked
    public void attackCombat(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();            
            Collider2D[] damagedBoss = Physics2D.OverlapCircleAll(attackLoc.position, attackRange, enemy);
            for(int i = 0; i < damagedBoss.Length; i++){
                damagedBoss[i].GetComponent<BossHP>().takeDamageBoss(attackDamage);
            }
        } 
    }

   void Attack(){
        animation1.SetTrigger("Attack");  
    }      
    
    //draw wire sphere to detect enemy within attack radius
    void OnDrawGizmosSelected(){
        if(attackLoc == null){
        return;
    }    
    Gizmos.DrawWireSphere(attackLoc.position, attackRange);
}
}


