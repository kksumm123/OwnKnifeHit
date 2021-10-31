using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI<GameOverUI>
{
    Text scoreText;
    Text stageText;
    Transform banner;
    protected override void Init()
    {
        scoreText = transform.Find("Banner/ScoreText").GetComponent<Text>();
        stageText = transform.Find("Banner/StageText").GetComponent<Text>();
        banner = transform.Find("Banner");
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
