﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    //public Player player;

    void Start()
    {
        //Debug.Log(Global.overallScore);
        scoreText.text = "SCORE: " + Global.overallScore.ToString()
        + "\n" + "MAX SCORE: " + Global.maxScore.ToString();
    }
    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
    }
}
