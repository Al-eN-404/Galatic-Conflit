using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    public int h = 3;
    public int c;
    public int d = 1;
    public int deathcount = 0;
    public GameObject enemyPrefab;

    private bool enemyDestroyed = false; // Flag to track if enemy is destroyed

    void Start()
    {
        c = h;
        PlayerPrefs.SetString("kills", "0");

    }

    void OnCollisionEnter(Collision col)
    {
        if (!enemyDestroyed && (col.gameObject.name == "enemy" || col.gameObject.name == "enemy(Clone)"))
        {
            c -= d;
            print("Current health is " + c);
            if (c <= 0)
            {
                
                Destroy(col.gameObject);
                enemyDestroyed = true; // Set the flag to true after destroying the enemy
                SpawnEnemy();
               
            }
        }
    }

    void SpawnEnemy()
    {
        deathcount++; // Increment death count after spawning new enemy
        PlayerPrefs.SetString("kills", deathcount.ToString());
        ScoreHandler.scoreCount+=1;
        print("Death Count is " + deathcount);
        // Set the spawn position to (102, 3, 75)
        Vector3 spawnPosition = new Vector3(102f, 3f, 75f);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        check enemyCheckScript = newEnemy.GetComponent<check>();
        if (enemyCheckScript != null)
        {
            enemyCheckScript.h = h;
            enemyCheckScript.c = h;
        }
        else
        {
            Debug.LogError("check script not found on the enemy prefab.");
        }
    }
}