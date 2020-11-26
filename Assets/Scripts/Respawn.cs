using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    //respawn variables
    public float respawnTime;
    bool respawn = false;
    float resetGame;
    
    // Update is called once per frame
    void Update()
    {
        if(respawn && resetGame <= Time.time){           
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void restartScene(){
        respawn = true;
        resetGame = Time.time + respawnTime;        
    }

}
