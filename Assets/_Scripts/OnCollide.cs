using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollide : MonoBehaviour
{
    public GameObject DialogueManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("SilverKey"))
        {
            gameObject.tag = "NextDoor";
            GetComponent<AudioSource>().Play();

            //if (other.gameObject != null)
            //{
            Destroy(other.gameObject);
            //}

        }
        else if (other.transform.tag.Equals("Player"))
        {
            DialogueManager.SetActive(true);
        }
    }
}