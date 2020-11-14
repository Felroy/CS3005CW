using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public float enemyMaxHP;
    private float currentEnemyHP;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHP = enemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damage){
        currentEnemyHP = currentEnemyHP - damage;
        Debug.Log(currentEnemyHP);
        if (currentEnemyHP <= 0){
            
            kill();
            
        }
    }

    void kill(){
        Destroy(gameObject);

    }
}
