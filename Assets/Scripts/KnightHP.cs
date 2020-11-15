using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHP : MonoBehaviour
{
    public float maxKnightHP;
    public Animator deathAnim;
    private float currentHP;
    KnightController deathMovement;

    //playerHPUI HUD variables
    public Slider hpSlider;
    public Gradient gradient;
    public Image fill;
    


    void Start()
    {
        currentHP = maxKnightHP;
        deathMovement = GetComponent<KnightController>();

        hpSlider.maxValue = maxKnightHP;
        hpSlider.value = maxKnightHP;

        fill.color = gradient.Evaluate(1f);

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
        hpSlider.value = currentHP;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);

        

        if (currentHP <= 0){
            kill();
        }

    }

    public void kill(){
        deathAnim.SetTrigger("isDead");
        Destroy(gameObject);

    }

    
}
