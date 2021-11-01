using DG.Tweening;
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
    float originBannnerLocalPositionY;
    protected override void Init()
    {
        scoreText = transform.Find("Banner/ScoreText").GetComponent<Text>();
        stageText = transform.Find("Banner/StageText").GetComponent<Text>();
        banner = transform.Find("Banner");
        transform.Find("RestartButton")
                 .GetComponent<Button>().onClick
                 .AddListener(() => RestartGame());

        originBannnerLocalPositionY = banner.transform.localPosition.y;
        CloseUI();
    }

    bool isRestartable = false;
    void RestartGame()
    {
        if (isRestartable)
            GameManager.Instance.RestartGame();
    }

    float duration = 2f;
    new public void ShowUI()
    {
        base.ShowUI();

        scoreText.text = ScoreUI.Instance.GetScore().ToString();
        stageText.text = $"STAGE {StageUI.Instance.GetStageValue()}";

        isRestartable = false;
        banner.DOLocalMoveY(originBannnerLocalPositionY + (Screen.height * 0.5f), 0);
        banner.DOLocalMoveY(originBannnerLocalPositionY, duration)
              .SetEase(Ease.OutBounce)
              .OnComplete(() => isRestartable = true);
    }
}
