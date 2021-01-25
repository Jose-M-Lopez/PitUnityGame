using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class InteractScript : MonoBehaviour
{
   private Camera cam;
   public Text interactText;
   public bool doorUnlocked = false;
   bool isOpened = false;
   public bool keyHeld = false;
   public bool inMenu = false;
   public bool computerDone = false;
   public GameObject myCrowbar;
   public GameObject myAxe;
   public GameObject note;
   public GameObject note2;
   public GameObject keypad;
   public GameObject computer;
   public GameObject health;
   public GameObject score;
   public GameObject pauseMenu;
   
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
        {
            switch (hit.transform.tag)
            {
                case "Water":
                    Highlight(hit.transform.gameObject);
                
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameControl.control.health += 30;
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case "Canned":
                    Highlight(hit.transform.gameObject);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameControl.control.health += 20;
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case "Keypad":
                    interactText.enabled = true;
                    GameControl.control.stopCheck = true;

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        keypad.SetActive(true);
                        inMenu = true;
                        GetComponent<FirstPersonController>().enabled = false;
                        Cursor.visible = true;
                        interactText.text = "Q-exit";
                        Cursor.lockState = CursorLockMode.None;
                        health.SetActive(false);
                        score.SetActive(false);
                        
                    }
                    break;
                case "LockedDoor":
                    {
                        if (doorUnlocked)
                        {
                        Highlight(hit.transform.gameObject);

                            if (Input.GetKeyDown(KeyCode.E))
                            {
                                hit.transform.gameObject.GetComponent<AudioSource>().Play();

                                if (isOpened)
                                {
                                    hit.transform.Rotate(0,-90,0);
                                    isOpened = false;
                                }
                                else
                                {
                                    hit.transform.Rotate(0,90,0);
                                    isOpened = true;
                                }
                            }
                        }
                    }
                    break;
                case "SilverKey":
                    {
                        interactText.enabled = true;
                        interactText.text = "E-pickup, Q-drop";
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.transform.parent = gameObject.transform;
                            keyHeld = true;
                        }
                    }
                    break;
                case "NextDoor":
                    {
                        Highlight(hit.transform.gameObject);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
                            GameObject.Find("Transition").GetComponent<TransitionScript>().sceneToLoad = "Floor 2";
                        }
                    }
                    break;
                case "Laptop":
                    Highlight(hit.transform.gameObject);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GameControl.control.stopCheck = true;
                        hit.transform.gameObject.GetComponents<AudioSource>()[1].Play();
                        inMenu = true;

                        interactText.text = "Q-exit";

                        if (computerDone)
                        {
                            computer.SetActive(false);
                            note2.SetActive(true);
                        }
                        else
                        {
                            computer.SetActive(true);
                            GetComponent<FirstPersonController>().enabled = false;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                            GameControl.control.stopCheck = true;
                            health.SetActive(false);
                            score.SetActive(false);
                        }
                    }
                    break;
                case "CodeNote":
                    {
                        Highlight(hit.transform.gameObject);

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            hit.transform.gameObject.GetComponent<AudioSource>().Play();

                            note.SetActive(true);
                        }
                        break;
                    }
                case "Crowbar":
                    {
                        Highlight(hit.transform.gameObject);
                        interactText.text = "E-equip";

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Destroy(hit.transform.gameObject);
                            myCrowbar.SetActive(true);
                        }
                    }
                    break;
                case "Axe":
                    {
                        Highlight(hit.transform.gameObject);

                        interactText.text = "E-equip";

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Destroy(hit.transform.gameObject);
                            myCrowbar.SetActive(false);
                            myAxe.SetActive(true);
                        }
                    }
                    break;
                case "ExitDoor":
                    {
                        interactText.enabled = true;
                        interactText.text = "E-escape";
                        if (Input.GetKeyDown(KeyCode.E))
                            {
                              GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
                              GameObject.Find("Transition").GetComponent<TransitionScript>().sceneToLoad = "Outro";
                            }
                    }
                    break;
                default:
                    interactText.text = "Press 'E'";
                    interactText.enabled = false;
                    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
                    note.SetActive(false);
                    note2.SetActive(false);
                    GameControl.control.stopCheck = false;
                    health.SetActive(true);
                    score.SetActive(true);

                    foreach (GameObject obj in allObjects)
                    {
                        if (obj.GetComponent<Outline>())
                        {
                            Destroy(obj.GetComponent<Outline>());
                        }
                    }
                    break;

            }
        }

        if (keyHeld && Input.GetKeyDown(KeyCode.Q))
        {
            GameObject key = GameObject.Find("Silver Key");
            key.transform.parent = null;
            keyHeld = false;
            inMenu = false;
        }

        if (inMenu == false && Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            inMenu = true;
            Time.timeScale = 0;
        }

        if (inMenu && Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<FirstPersonController>().enabled = true;
            keypad.SetActive(false);
            computer.SetActive(false);
            inMenu = false;
            Cursor.visible = false;
        }
    }

    private void Highlight(GameObject obj)
    {
        if (!obj.GetComponent<Outline>())
        {
            interactText.enabled = true;
            var outline = obj.AddComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
        }
    }

}