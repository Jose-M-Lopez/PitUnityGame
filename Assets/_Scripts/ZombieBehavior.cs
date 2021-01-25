using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    private Transform myTransform;
    public GameObject target;
    public float attackDistance;
    public float spotDistance;
    public float speed;
    public float rateOfAttack;
    private float nextAttack;
    public int health;
    public GameObject Explosion;
    AudioSource[] audioFiles;

    void Start()
    {
        myTransform = transform;
        nextAttack = Time.time;
        audioFiles = GetComponents<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(myTransform.position, target.transform.position);

        if (distance < attackDistance)
        {

            //AI in range to attack player
            GetComponent<Animation>().Play("Z_Attack");
            if (!audioFiles[2].isPlaying)
            {
                foreach (AudioSource clip in audioFiles) { clip.Stop(); }
                audioFiles[2].Play();
            }
            myTransform.LookAt(target.transform);
            myTransform.position = Vector3.MoveTowards(myTransform.position, target.transform.position, speed * Time.deltaTime);

            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + rateOfAttack;
                

                GameControl.control.health -= 15;

                if (GameControl.control.health <= 0)
                {
                    GameControl.control.stopCheck = true;
                    GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
                    GameObject.Find("Transition").GetComponent<TransitionScript>().sceneToLoad = "DeathScene";
                }
            }

        }
        else if (distance <= spotDistance)
        {
            //AI in range to chase player
            GetComponent<Animation>().Play("Z_Run");
            if (!audioFiles[1].isPlaying)
            {
                foreach (AudioSource clip in audioFiles) { clip.Stop(); }
                audioFiles[1].Play();
            }
            myTransform.LookAt(target.transform);
            myTransform.position = Vector3.MoveTowards(myTransform.position, target.transform.position, speed * Time.deltaTime);

        }
        else
        {
            //Idle state
            GetComponent<Animation>().Play("Z_Idle");
            if (!audioFiles[0].isPlaying)
            {
                foreach (AudioSource clip in audioFiles) { clip.Stop(); }
                audioFiles[0].Play();
            }
        }

    }

    public void CrowbarHit()
    {
        health -= 8;
        GameControl.control.points += 2;

        if (health <= 0)
        {
            GameControl.control.points += 100;

            GameObject expl = (GameObject)Instantiate(Explosion, myTransform.position, myTransform.rotation);
            Destroy(gameObject);
            Destroy(expl, 1);
        }

    }

    public void AxeHit()
    {
        health -= 11;
        GameControl.control.points += 2;

        if (health <= 0)
        {
            GameControl.control.points += 100;

            GameObject expl = (GameObject)Instantiate(Explosion, myTransform.position, myTransform.rotation);
            Destroy(gameObject);
            Destroy(expl, 1);
        }
    }
}
