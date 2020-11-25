using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightHP : MonoBehaviour{
    private float currentHP;
    public float maxKnightHP;
    public Animator deathAnim;
    
    KnightController deathMovement;

    //playerHPUI HUD variables
    public Text deathText;
    private bool isDamaged;
    public bool dead;  
    Color splatColor = new Color(15f, 0f, 0f, 0.5f);
    float fade = 3f;
    public Slider hpSlider;
    public Image hitSplat;
    public Gradient gradient;
    public Image fill;    

    //sfx
    public AudioClip losingHP;
    AudioSource audiosrc;
    
    //respawn
    public Respawn respawnManager;    


    void Start(){
        currentHP = maxKnightHP;
        deathMovement = GetComponent<KnightController>();

        hpSlider.maxValue = maxKnightHP;
        hpSlider.value = maxKnightHP;
        fill.color = gradient.Evaluate(1f);
        isDamaged = false;

        audiosrc = GetComponent<AudioSource>();
    }
    
    void Update(){
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
        //audio code      
        audiosrc.clip = losingHP;
        audiosrc.PlayOneShot(losingHP); 
        //       
        hpSlider.value = currentHP;
        isDamaged = true;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);        

        if (currentHP <= 0){                      
            kill();
        }

    }

    //recover hp on colliding with potion
    public void recoverHP(float potionHP1){
        currentHP += potionHP1;
        if(currentHP > maxKnightHP){
            currentHP = maxKnightHP;
        }
        hpSlider.value = currentHP;
        isDamaged = false;
        fill.color = gradient.Evaluate(hpSlider.normalizedValue);        

    }

    public void kill(){
        if(!dead){
        deathAnim.SetBool("isDeado", !dead);
        Destroy(gameObject, 1);
        dead = true;
        hitSplat.color = splatColor;

        Animator gameOver = deathText.GetComponent<Animator>();
        gameOver.SetTrigger("gameOver");
        respawnManager.restartScene();
        }

    }

    
}
