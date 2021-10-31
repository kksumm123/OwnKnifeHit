using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI<GameOverUI>
{
    Text scoreText;
    Text stageText;
    protected override void Init()
    {
        scoreText = transform.Find("Banner/ScoreText").GetComponent<Text>();
        stageText = transform.Find("Banner/StageText").GetComponent<Text>();
        transform.Find("RestartButton")
                 .GetComponent<Button>().onClick
                 .AddListener(() => RestartGame());
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
