using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc1 : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName = "NewSceneName";

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to wait and then load the scene
        StartCoroutine(TransitionAfterDelay(5f));
    }

    // Coroutine to wait for a specified delay and then load the scene
    IEnumerator TransitionAfterDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
