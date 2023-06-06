using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highScoreText;

    int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        UpdateHighScore();
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
    }

    public void UpdateScore()
    {
        score += 1;
        currentScoreText.text = score.ToString();
        UpdateHighScore();
    }
}
