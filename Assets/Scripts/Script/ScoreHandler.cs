using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public Text score;
    public static string scoreCount;

    //public static int scoreCount;


    //scoreCount = PlayerPrefs.GetString("kills");

      void Start()
    {
          score.text="Score : 20"; 
          //score.text="Score : "+scoreCount;
    }
}