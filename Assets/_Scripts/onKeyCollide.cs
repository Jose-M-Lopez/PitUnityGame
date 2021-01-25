using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onKeyCollide : MonoBehaviour
{
    public GameObject DialogueManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            if (other.gameObject.GetComponent<InteractScript>().keyHeld == true)
            {
                DialogueManager.SetActive(true);
            }
        }
    }
}
