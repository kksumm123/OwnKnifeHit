using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : BaseUI<StageUI>
{
    public List<Image> stageIcons = new List<Image>();
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

    float h;
    float s;
    float v;
    float colorStepValue = 30f;
    internal void IncreaseStageValue()
    {
        // ���� �ٲ��ֱ�
        Color.RGBToHSV(stageIcons[stage % 5].color, out h, out s, out v);
        stageIcons[stage % 5].color = Color.HSVToRGB((1f / 256) * colorStepValue + h, 1, 1);

        // �������� ����
        stage++;
        stageValue.text = $"STAGE {stage}";

        // ���������� 5�� ����� ��, ��Ż ������ ī��Ʈ 1 ����
        if (stage % 5 == 0)
            GameManager.Instance.IncreaseTotalKnifeCount();
    }

    internal int GetStageValue()
    {
        return stage;
    }
}
