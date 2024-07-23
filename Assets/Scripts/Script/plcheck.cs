using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class plcheck : MonoBehaviour
{
    public int h = 10; // Initial health
    public int c; // Current health
    public int d = 1; // Damage taken per collision

    void Start()
    {
        c = h; // Initialize current health

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "player")
        {
            Debug.Log("Collision detected!"); // Debug log to check collision
            c -= d; // Reduce health by damage amount
            Debug.Log("Current health is: " + c); // Debug log to check updated health

            if (c <= 0)
            {
                // Handle player death (e.g., scene transition or game over logic)
                Destroy(col.gameObject);
            }
        }


        IEnumerator LoadSceneAfterDelay()
        {
            yield return new WaitForSeconds(90); // Wait for 10 seconds

            // Load the new scene
            SceneManager.LoadScene("New Scene 1");
        }
    }
}
