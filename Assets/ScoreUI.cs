using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : BaseUI<ScoreUI>
{
    int score = 0;
    Text scoreText;
    void Start()
    {
        scoreText = transform.Find("Value").GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    internal void AddPoint(int addValue)
    {
        score += addValue;
        scoreText.text = score.ToString();
    }

    internal int GetScore()
    {
        return score;
    }
}
