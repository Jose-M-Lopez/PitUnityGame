using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarScript : MonoBehaviour
{
    private Transform myTransform;
    private Animator anim;
    public float hitrate;
    private float time2hit;
    private AudioSource swing;

    void Start()
    {
        myTransform = transform;
        time2hit = Time.time;
        anim = GetComponent<Animator>();
        anim.speed = 1.5f;
        swing = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision otherObject)
    {
        if (otherObject.transform.tag.Equals("enemy"))
        {
            otherObject.transform.SendMessage("CrowbarHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > time2hit && GameObject.Find("Player").GetComponent<InteractScript>().inMenu == false)
        {
           
            anim.Play("CrowbarSwing", 0,0);
            swing.Play();
           

            time2hit = Time.time + hitrate;
        }
    }
}
