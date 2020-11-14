using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHP : MonoBehaviour
{
    public float maxKnightHP;
    public Animator deathAnim;
    private float currentHP;
    KnightController deathMovement;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxKnightHP;
        deathMovement = GetComponent<KnightController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage){
        if(damage <= 0){
            return;
        }
        currentHP -= damage;

        if (currentHP <= 0){
            kill();
        }

    }

    public void kill(){
        deathAnim.SetTrigger("isDead");
        Destroy(gameObject);

    }

    
}
