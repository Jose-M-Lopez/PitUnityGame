using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScript : MonoBehaviour
{
    Renderer rend;
    public int waitTime;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        StartCoroutine(Show());
    }

    public IEnumerator Show()
    {
        float dt = Time.deltaTime;
        yield return new WaitForSeconds(dt*waitTime);
        rend.enabled = true;
    }
}