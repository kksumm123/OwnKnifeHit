using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleScoreUI : BaseUI<AppleScoreUI>
{
    private const string appleScoreKey = "AppleScore";
    int appleScore = 0;
    Text appleScoreText;
    void Start()
    {
        appleScore = PlayerPrefs.GetInt(appleScoreKey, 0);

        appleScoreText = transform.Find("Value").GetComponent<Text>();
        appleScoreText.text = appleScore.ToString();
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt(appleScoreKey, appleScore);
    }

    internal void AddApplePoint(int addValue)
    {
        appleScore += addValue;
        appleScoreText.text = appleScore.ToString();
    }
}
