using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    float minimumY; 
    public Transform playerLoc;
    public float camIntensity;
    Vector3 offset;    

    void Start()
    {
        offset = transform.position - playerLoc.position;
        minimumY = transform.position.y;
    }

    void FixedUpdate()
    {
        if (playerLoc != null){
            Vector3 targetCamLoc = playerLoc.position + offset;
            transform.position = Vector3.Lerp (transform.position, targetCamLoc, camIntensity*Time.deltaTime);
            if(transform.position.y < minimumY) {
            transform.position = new Vector3 (transform.position.x, minimumY, transform.position.z);
            }
        }               
    }
}
