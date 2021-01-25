using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
 
    public void btnPressed()
    {
        switch (this.name)
        {
            case "Resume":
                GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
                GameObject.Find("Player").GetComponent<InteractScript>().inMenu = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                menu.SetActive(false);
                Time.timeScale = 1;
                break;
            case "Restart":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
                Time.timeScale = 1;
                GameControl.control.health = 100;
                GameControl.control.points = 0;
                break;
            case "Exit":
                Exit();
                break;

        }
    }

    public void Exit()
    {
        //Stops the editor, Stops application if not in editor mode
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}


