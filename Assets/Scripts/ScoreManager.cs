using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private int numPlatforms = 31;
    public static int score;       
    Text text;                     


    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update ()
    {
        text.text = "Platforms left: " + (numPlatforms - score);
//Debug.Log(score);
        if(numPlatforms - score <= 0)
        {
            Application.LoadLevel(3);
        }
    }
}