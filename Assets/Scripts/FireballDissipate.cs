using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDissipate : MonoBehaviour
{

    public float lifeDuration;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, lifeDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
