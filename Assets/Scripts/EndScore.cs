using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

    private int numPlatforms = 31;
    public static int score;
    Text text;


    void Awake()
    {
        text = GetComponent<Text>();
        score = ScoreManager.score;
        text.text = "Number of platforms standing: " + (numPlatforms - score) + "\nNumber of platforms fallen: " + score;
    }

   /* void Update()
    {
        text.text = "Number of platforms standing: " + (numPlatforms - score) + "\nNumber of platforms gone: " +  score;
    }*/
}
