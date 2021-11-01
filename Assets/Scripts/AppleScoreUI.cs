using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleScoreUI : BaseUI<AppleScoreUI>
{
    int appleScore = 0;
    Text appleScoreText;
    void Start()
    {
        appleScoreText = transform.Find("Value").GetComponent<Text>();
        appleScoreText.text = appleScore.ToString();
    }

    internal void AddApplePoint(int addValue)
    {
        appleScore += addValue;
        appleScoreText.text = appleScore.ToString();
    }
}
