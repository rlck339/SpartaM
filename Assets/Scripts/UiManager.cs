using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI highScoreText;

    
    void Start()
    {
        

        
    }

    public void SetRestart()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = ("Score : " + score);
    }
    public void UpdateHighScore(int highscore)
    {
        

        highScoreText.text = "High  : " + highscore;
    }
   
    
}
