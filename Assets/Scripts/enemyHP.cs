using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHP : MonoBehaviour
{ 
    float currentEnemyHP;
    public float enemyMaxHP;    

    
    //enemy HP HUD variables
    public Slider enemyHPSlider;  
    public Gradient enemyGrad;
    public Image fill;
        

    //enemy loot
    public bool loot;
    public GameObject potion;

    void Start()
    {
        currentEnemyHP = enemyMaxHP;
        enemyHPSlider.maxValue = currentEnemyHP;
        enemyHPSlider.value = currentEnemyHP;    
        
        fill.color = enemyGrad.Evaluate(1f);
    }

    public void takeDamage(float damage){

        enemyHPSlider.gameObject.SetActive(true);
        currentEnemyHP = currentEnemyHP - damage;
        enemyHPSlider.value = currentEnemyHP;
        fill.color = enemyGrad.Evaluate(enemyHPSlider.normalizedValue);

        
        if (currentEnemyHP <= 0){            
            kill();                           
        }
    }

    void kill(){              
        Destroy(transform.parent.gameObject);
        if(loot){
            Instantiate(potion, transform.position, transform.rotation);
        }
        
   }
}
