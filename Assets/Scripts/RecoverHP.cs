using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHP : MonoBehaviour
{
    public float potionHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if(other.tag == "Player"){
            KnightHP knightHP = other.gameObject.GetComponent<KnightHP>();
            knightHP.recoverHP(potionHP);
            Destroy(gameObject);
        }
    }
}
