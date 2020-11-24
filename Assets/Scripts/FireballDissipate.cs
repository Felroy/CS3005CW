using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDissipate : MonoBehaviour
{

    public float lifeDuration;

    void Awake()
    {
        Destroy(gameObject, lifeDuration);
    }
}
