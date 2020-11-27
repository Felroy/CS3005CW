using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{ 
    float currentBossHP;
    float phase2;
    public float BossMaxHP = 100;    

    
    //enemy HP HUD variables
    public Slider enemyHPSlider;  
    public Gradient enemyGrad;
    public Image fill;


    //enemy loot
    public bool loot;
    public GameObject potion;

    void Start()
    {
        currentBossHP = BossMaxHP;
        enemyHPSlider.maxValue = currentBossHP;
        enemyHPSlider.value = currentBossHP;  
        phase2 = BossMaxHP/4; 

        fill.color = enemyGrad.Evaluate(1f);
    }

    public void takeDamageBoss(float damage){

        enemyHPSlider.gameObject.SetActive(true);
        currentBossHP = currentBossHP - damage;
        Debug.Log(currentBossHP);

        enemyHPSlider.value = currentBossHP;
        fill.color = enemyGrad.Evaluate(enemyHPSlider.normalizedValue);

        if (currentBossHP <= phase2){
            GetComponent<Animator>().SetBool("Under50", true);
        }
        if (currentBossHP <= 0){            
            killBoss();                           
        }
    }

    void killBoss(){              
        Destroy(gameObject);
        //Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if(loot){
            Instantiate(potion, transform.position, transform.rotation);
        }
        
   }
}
