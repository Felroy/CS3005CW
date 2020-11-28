using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHP : MonoBehaviour
{
    public float potionHP;
    void OnTriggerEnter2D (Collider2D other){
        if(other.tag == "Player"){
            KnightHP knightHP = other.gameObject.GetComponent<KnightHP>();
            knightHP.recoverHP(potionHP);
            Destroy(gameObject);
        }
    }
}
