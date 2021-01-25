using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    public Image fade;
    public int waitTime;
    float timer = 0;

    void Start()
    {
        fade.canvasRenderer.SetAlpha(0.0f);
    }

    void Update()
    {
        if (timer < waitTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            fadeIn();
        }
    }

    void fadeIn()
    {
        float dt=Time.deltaTime;
        fade.CrossFadeAlpha(1, 350 * dt, false);
    } 
}