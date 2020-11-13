using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform playerLoc;
    public float camIntensity;
    Vector3 offset;
    float minimumY; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerLoc.position;
        minimumY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamLoc = playerLoc.position + offset;
        transform.position = Vector3.Lerp (transform.position, targetCamLoc, camIntensity*Time.deltaTime);
        
        if(transform.position.y < minimumY) {
            transform.position = new Vector3 (transform.position.x, minimumY, transform.position.z);
        }
    }
}
