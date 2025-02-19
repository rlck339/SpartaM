using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    private int highScore = 0;  // 최고 점수 변수 추가



    UiManager uiManager;
    public UiManager UiManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();

        // 저장된 최고 점수 불러오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateHighScore(highScore); // UI에 최고 점수 표시
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        // 최고 점수 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // 최고 점수 저장
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("ButtonScene");

        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;

        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);

        // 최고 점수 갱신
        if (currentScore > highScore)
        {
            highScore = currentScore;
            uiManager.UpdateHighScore(highScore);
        }
    }
}

