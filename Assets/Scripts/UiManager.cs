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
        if (restartText == null)
            Debug.LogError("restart text is null");

        if (scoreText == null)
            Debug.LogError("socre text is null");

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        if (restartText == null)
        {
            
            return;
        }
        restartText.gameObject.SetActive(true);
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
