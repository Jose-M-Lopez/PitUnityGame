using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaitForTransition : MonoBehaviour
{
    public int waitTime;
    public bool isWaiting = true;
 
    void Start()
    {
        if (isWaiting)
        {
            StartCoroutine(waitForTransition());
        }
    }

    IEnumerator waitForTransition()
    {
        yield return new WaitForSeconds(waitTime);

        if (SceneManager.GetActiveScene().name == "DeathScene")
        {
            loadPrev();
        }
        else
        {
            loadNext();
        }
    }

    public void loadNext()
    {
        GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
    }

    public void loadPrev()
    {
        GameObject.Find("Transition").GetComponent<TransitionScript>().sceneToLoad = GameControl.currentScene;
        GameObject.Find("Transition").GetComponent<TransitionScript>().transition = true;
        GameControl.control.points = 0;
        GameControl.control.health = 100;
    }

}