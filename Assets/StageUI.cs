using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUI : BaseUI<StageUI>
{
    void Start()
    {
        whiteScreenCanvasGroup = transform.Find("WhiteScreen").GetComponent<CanvasGroup>();
        whiteScreenCanvasGroup.alpha = 0;
    }

    CanvasGroup whiteScreenCanvasGroup;
    float whiteScreenDuration = 0.5f;
    internal void WhiteScreen()
    {
        whiteScreenCanvasGroup.alpha = 1;
        DOTween.To(() => 1, x => whiteScreenCanvasGroup.alpha = x, 0, whiteScreenDuration)
               .OnComplete(() => GameManager.Instance.GameState = GameState.Playing);
    }
}
