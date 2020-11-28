using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{ 
    float currentBossHP;
    float phase2;
    public float BossMaxHP = 100; 
    public bool iframes = false;
    Rigidbody2D bossRB;   
        
    //enemy HP HUD variables
    public Slider enemyHPSlider;  
    public Gradient enemyGrad;
    public Image fill;
    public Text winText;
    public Text bossName;
    public MenuManager menu;
        
    //enemy loot
    public bool loot;
    public GameObject potion;

    void Start()
    {   
        bossRB = GetComponent<Rigidbody2D>();
        currentBossHP = BossMaxHP;
        enemyHPSlider.maxValue = currentBossHP;
        enemyHPSlider.value = currentBossHP;  
        phase2 = BossMaxHP/4; 

        fill.color = enemyGrad.Evaluate(1f);
    }

    public void takeDamageBoss(float damage){
        if(iframes){
            return;
        }

        enemyHPSlider.gameObject.SetActive(true);
        currentBossHP = currentBossHP - damage;
        GetComponent<Animator>().SetTrigger("hurt");

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
        bossRB.velocity = Vector2.zero;
        GetComponent<Animator>().SetBool("bossDead", true);    
        Destroy(gameObject, 1);
        bossName.enabled = false;
        Animator gameOver = winText.GetComponent<Animator>();
        gameOver.SetTrigger("win");
        menu.enableMenu();
       
                
        if(loot){
            Instantiate(potion, transform.position, transform.rotation);
        }        
   }
}
