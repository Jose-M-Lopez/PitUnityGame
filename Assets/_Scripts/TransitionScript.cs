using UnityEngine.SceneManagement;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public Animator animator;
    public bool transition = false;
    public string sceneToLoad;
   
    void Update()
    {
        if (transition)
        {
            fadeToScene(sceneToLoad);
            transition = false;
        }

        if (sceneToLoad == "Menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void fadeToScene(string newScene)
    {
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
