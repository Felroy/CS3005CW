using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public int nAttDmg;
    
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void Attack()
	{
		Vector3 attackLoc = transform.position;
		attackLoc += transform.right * attackOffset.x;
		attackLoc += transform.up * attackOffset.y;

		Collider2D colliderDetect = Physics2D.OverlapCircle(attackLoc, attackRange, attackMask);
		if (colliderDetect != null){
            colliderDetect.GetComponent<KnightHP>().takeDamage(nAttDmg);
        }		
	}

    void OnDrawGizmosSelected()
	{
		Vector3 gizmoLoc = transform.position;
		gizmoLoc += transform.right * attackOffset.x;
		gizmoLoc += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(gizmoLoc, attackRange);
	}

}
