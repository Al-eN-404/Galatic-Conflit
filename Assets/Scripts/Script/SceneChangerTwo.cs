using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class SceneChangerTwo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(6); // Wait for 10 seconds

        // Load the new scene
        SceneManager.LoadScene("New Scene 1");
    }   
}