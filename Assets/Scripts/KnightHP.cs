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
    private bool isDamaged;
    public bool dead;
  
    Color splatColor = new Color(15f, 0f, 0f, 0.5f);
    float fade = 5f;
    public Slider hpSlider;
    public Image hitSplat;
    public Gradient gradient;
    public Image fill;
    


    void Start()
    {
        currentHP = maxKnightHP;
        deathMovement = GetComponent<KnightController>();

        hpSlider.maxValue = maxKnightHP;
        hpSlider.value = maxKnightHP;

        fill.color = gradient.Evaluate(1f);

        isDamaged = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isDamaged){
            hitSplat.color = splatColor;
        }
        else {
            hitSplat.color = Color.Lerp(hitSplat.color, Color.clear, fade= Time.deltaTime);
        }
        isDamaged = false;
    }

    public void takeDamage(float damage){
        if(damage <= 0){
            return;
        }
        
        currentHP -= damage;
        hpSlider.value = currentHP;
        isDamaged = true;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);

        

        if (currentHP <= 0){
                      
            kill();
        }

    }

    public void kill(){
        if(!dead){
        deathAnim.SetBool("isDeado", !dead);
        Destroy(gameObject, 1);
        dead = true;
        }

    }

    
}
