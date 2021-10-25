using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeCountUI : BaseUI<KnifeCountUI>
{
    Image baseIcon;
    protected override void Init()
    {
        baseIcon = transform.Find("KnifeCountUI/Knives/BaseIcon").GetComponent<Image>();
    }

    public List<Image> knives = new List<Image>();
    public void SetKnifeIcon(int knifeCount)
    {
        baseIcon.gameObject.SetActive(true);
        for (int i = 0; i < knifeCount; i++)
        {
            var newKnifeIcon = Instantiate(baseIcon, baseIcon.transform.parent);
            knives.Add(newKnifeIcon);
        }
        baseIcon.gameObject.SetActive(false);
    }
}
