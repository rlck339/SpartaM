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
    private int highScore = 0;  // �ְ� ���� ���� �߰�



    UiManager uiManager;
    public UiManager UiManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UiManager>();

        // ����� �ְ� ���� �ҷ�����
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateHighScore(highScore); // UI�� �ְ� ���� ǥ��
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        // �ְ� ���� ����
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // �ְ� ���� ����
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

        // �ְ� ���� ����
        if (currentScore > highScore)
        {
            highScore = currentScore;
            uiManager.UpdateHighScore(highScore);
        }
    }
}

