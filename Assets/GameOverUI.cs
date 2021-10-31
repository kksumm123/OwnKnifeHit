using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI<GameOverUI>    
{
    Text scoreText;
    Text stageText;
    void Start()
    {
        scoreText = transform.Find("Banner/ScoreText").GetComponent<Text>();
        stageText = transform.Find("Banner/StageText").GetComponent<Text>();
        transform.Find("RestartButton")
                 .GetComponent<Button>().onClick
                 .AddListener(() => RestartGame());

        CloseUI();
    }

    void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    new public void ShowUI()
    {
        base.ShowUI();
    }
}
