using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public int health;
    public int points;
    public static string currentScene;
    public bool stopCheck = false;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Floor 1" || SceneManager.GetActiveScene().name == "Floor 2")
        {
            stopCheck = false;
            currentScene = SceneManager.GetActiveScene().name;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
       
        if (control == null) //If this is the first scene...
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        } 
        else if(control != this) //Any subsequent scene that uses GameControl...
        {
            //If I am the new instance of GameControl script
            Destroy(gameObject);
        }

    }

    void Update()
    {
        var activeScene = SceneManager.GetActiveScene().name;

        if (activeScene == "DeathScene" || activeScene == "Outro" || activeScene == "Menu" || activeScene == "Intro")
        {
            return;
        }

        if (stopCheck == false && GameObject.Find("Player").GetComponent<InteractScript>().inMenu == false)
        {
            GameObject scorePoints = GameObject.Find("ScoreText");
            scorePoints.GetComponent<Text>().text = "Score: " + points.ToString();

            GameObject healthPoints = GameObject.Find("HealthText");
            healthPoints.GetComponent<Text>().text = "Health: " + health.ToString();
        }
        
      if (SceneManager.GetActiveScene().name == "DeathScene")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
