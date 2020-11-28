using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {   
        gameObject.SetActive(false);      
    }   

    public void enableMenu(){
        gameObject.SetActive(true);
    }
}
