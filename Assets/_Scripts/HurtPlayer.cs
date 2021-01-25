using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;



public class HurtPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject respawn;
    private CharacterController controller;  

    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            GameControl.control.health -= 10;
           
            if (GameControl.control.health <= 0)
            {
                GameControl.control.stopCheck = true;
                GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
                GameObject.Find("Transition").GetComponent<TransitionScript>().sceneToLoad = "DeathScene";
            }
            else
            {
                controller.enabled = false;
                player.transform.position = respawn.transform.position;
                controller.enabled = true;
            }

        }
    }
}
