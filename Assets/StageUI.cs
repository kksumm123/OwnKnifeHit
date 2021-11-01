using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : BaseUI<StageUI>
{
    int stage = 0;
    Text stageValue;
    void Start()
    {
        stageValue = transform.Find("Value").GetComponent<Text>();
        whiteScreenCanvasGroup = transform.Find("WhiteScreen").GetComponent<CanvasGroup>();

        IncreaseStageValue();
        whiteScreenCanvasGroup.alpha = 0;
    }

    CanvasGroup whiteScreenCanvasGroup;
    float whiteScreenDuration = 0.5f;
    internal void WhiteScreen()
    {
        whiteScreenCanvasGroup.alpha = 1;
        DOTween.To(() => 1, x => whiteScreenCanvasGroup.alpha = x, 0, whiteScreenDuration)
               .OnComplete(() => GameManager.Instance.GameState = GameState.Playing)
               .SetLink(gameObject);
    }

    internal void IncreaseStageValue()
    {
        stage++;
        stageValue.text = $"STAGE {stage}";
    }
}
