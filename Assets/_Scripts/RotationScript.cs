using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private Transform myTransform; 
    public float x, y, z;
    public int waitTime;
    float timer = 0;
   
    void Start()
    {
        myTransform = transform; 
    }

    void Update()
    {
        if (timer < waitTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float dt = Time.deltaTime;
            myTransform.Rotate(x * dt, y * dt, z * dt);
        }
    }
}
