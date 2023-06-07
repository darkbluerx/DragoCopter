using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highScoreText;

    int score;
    bool IsDead;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        IsDead = false;
        currentScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        UpdateHighScore();
    }

    private void Update()
    {
       if(IsDead == false) UpdateScore();
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

    public void StopScore()
    {
        IsDead = true;
        currentScoreText.text = score.ToString();
    }
}
