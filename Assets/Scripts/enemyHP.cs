using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHP : MonoBehaviour
{ 
    private float currentEnemyHP;
    public float enemyMaxHP;
    public GameObject enemyDeathFX;
    
    //enemy HP HUD variables
    public Slider enemyHPSlider;  
    public Gradient enemyGrad;
    public Image fill;

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
        Debug.Log(currentEnemyHP);

        enemyHPSlider.value = currentEnemyHP;
        fill.color = enemyGrad.Evaluate(enemyHPSlider.normalizedValue);
        if (currentEnemyHP <= 0){            
            kill();            
        }
    }

    void kill(){
        Destroy(gameObject);
        //Instantiate(enemyDeathFX, transform.position, transform.rotation);

    }
}
