
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Add this line

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerStopped = false;
    private const float maxTime = 60.0f;
    public string sceneToLoad;  // Add this line to specify the scene to load

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!timerStopped)
        {
            float t = Time.time - startTime;

            if (t >= maxTime)
            {
                t = maxTime;
                timerStopped = true;
                 SceneManager.LoadScene("END");  // Add this line to load the new scene
            }

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }
    }
}
