using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class ComputerScript : MonoBehaviour
{
    private static int counter = 0;
    private GameObject[] buttons;
    public GameObject note;
    public GameObject computer;
    AudioSource[] audioFiles;

    void Start()
    {
        audioFiles = GameObject.Find("Laptop").GetComponents<AudioSource>();
        buttons = GameObject.FindGameObjectsWithTag("pcButton");
    }

    public void btnPressed()
    {
        switch (this.name)
        {
           case "@":
                if (counter == 0)
                {
                    this.GetComponent<Image>().color = Color.green;
                    ++counter;
                    audioFiles[2].Play();
                }
                else
                {
                    clearAll();
                    counter = 0;
                    audioFiles[0].Play();
                }
                break;
            case "#":
                {
                    if (counter == 1)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play(); 
                    }
                    break;
                }
            case "1":
                {
                    if (counter == 2)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }
            case "5":
                {
                    if (counter == 3)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }
            case "r":
                {
                    if (counter == 4)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play(); 
                    }
                    break;
                }
            case "&":
                {
                    if (counter == 5)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }
            case "x":
                {
                    if (counter == 6)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }
            case "3":
                {
                    if (counter == 7)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        ++counter;
                        audioFiles[2].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }
            case "s":
                {
                    if (counter == 8)
                    {
                        this.GetComponent<Image>().color = Color.green;
                        GameObject.Find("Player").GetComponent<InteractScript>().computerDone = true;
                        computer.SetActive(false);
                        note.SetActive(true);
                        GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
                        audioFiles[1].Play();
                    }
                    else
                    {
                        clearAll();
                        counter = 0;
                        audioFiles[0].Play();
                    }
                    break;
                }

        }
    }

    public void clearAll()
    {
        foreach (GameObject button in buttons)
        {
            button.GetComponent<Image>().color = new Color(82,82,82);
        }
    }
   
}
