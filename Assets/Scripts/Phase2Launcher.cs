using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2Launcher : MonoBehaviour
{
    public GameObject particle; 
    public Transform shootFrom;
    // Start is called before the first frame update
    public void particleLaunch(){
        Instantiate(particle, shootFrom.position, Quaternion.identity);
    }
}
