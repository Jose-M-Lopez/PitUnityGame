using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadScript : MonoBehaviour
{
    public GameObject code;
    Text codeText;
    string correct = "4891";
    AudioSource[] audioFiles;

    void Start()
    {
        codeText = code.GetComponent<Text>();
        audioFiles = GameObject.Find("Keypad").GetComponents<AudioSource>();
    }


    public void btnPressed()
    {  
        switch (this.name)
        {
            case "1":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "2":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "3":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "4":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "5":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "6":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "7":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "8":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "9":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "0":
                if (codeText.text.Length < 4)
                {
                    codeText.text += this.name;
                }
                break;
            case "C":
                    codeText.text = "";
                break;
            case "E":
                if (codeText.text == correct)
                {
                    GameObject.Find("Player").GetComponent<InteractScript>().doorUnlocked = true;
                    GameObject.Find("Keypad").GetComponent<AudioSource>();
                    audioFiles[0].Play();
                }
                else
                {
                    codeText.text = "";
                    audioFiles[1].Play();
                }
                break;

        }
    }
}
