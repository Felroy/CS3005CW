using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCombat : MonoBehaviour
{
    public Animator animation1;
    public Transform attackLoc;
    public float attackRange = 0.5f;
    public LayerMask enemy;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)){
            Attack();
        }
    }


   void Attack(){

    animation1.SetTrigger("Attack");    
    Collider2D[] damagedEnemy = Physics2D.OverlapCircleAll(attackLoc.position, attackRange, enemy);



}
}
