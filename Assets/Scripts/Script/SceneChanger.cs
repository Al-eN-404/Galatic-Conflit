using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(6); // Wait for 10 seconds

        // Load the new scene
        SceneManager.LoadScene("1 Start Scene 1");
    }
}