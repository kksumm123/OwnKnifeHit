using DG.Tweening;
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
        whiteScreenCanvasGroup = transform.Find("WhiteScreen").GetComponent<CanvasGroup>();
    }

    internal void AddPoint(int addValue)
    {
        score += addValue;
        scoreText.text = score.ToString();
    }

    CanvasGroup whiteScreenCanvasGroup;
    float whiteScreenDuration = 0.5f;
    internal void WhiteScreen()
    {
        whiteScreenCanvasGroup.alpha = 1;
        DOTween.To(() => 1, x => whiteScreenCanvasGroup.alpha = x, 0, whiteScreenDuration)
               .OnComplete(() => GameManager.Instance.GameState = GameState.Playing);
    }

    internal int GetScore()
    {
        return score;
    }
}
