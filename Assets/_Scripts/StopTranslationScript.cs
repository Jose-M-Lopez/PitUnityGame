using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTranslationScript : MonoBehaviour
{
    private Transform myTransform;
    public float x, y, z;
    public int waitTime;
    public int stopTime;
    float timer = 0;
    float stopTimer = 0;


    void Start()
    {
        myTransform = transform;
    }

    void Update()
    {
        stopTimer += Time.deltaTime;

        if (stopTimer < stopTime)
        {
            if (timer < waitTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                float dt = Time.deltaTime;
                myTransform.Translate(x * dt, y * dt, z * dt);
            }
        }
    }
}


