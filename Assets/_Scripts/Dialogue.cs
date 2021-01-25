using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueBtn;
    public GameObject player;
    public GameObject dialogueBox;
    public GameObject collider;
    public int x, y, z;

    void Start()
    {
        StartCoroutine(Type());
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<InteractScript>().inMenu = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.transform.LookAt(new Vector3(x, y, z));
    }

    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueBtn.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueBtn.SetActive(false);

        if (index < sentences.Length - 1)
        {
            ++index;
            dialogueText.text = "";
            StartCoroutine(Type());
        }
        else
        {
           /*dialogueText.text = "";
            continueBtn.SetActive(false);
            dialogueBox.SetActive(false);*/
            player.GetComponent<FirstPersonController>().enabled = true;
            player.GetComponent<InteractScript>().inMenu = false;
            Destroy(collider);
            Destroy(dialogueBox);
        }
    }
}
