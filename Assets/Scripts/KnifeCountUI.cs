using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeCountUI : BaseUI<KnifeCountUI>
{
    const string usableKnifeIconString = "UsableKnife";
    const string usedKnifeIconString = "UsedKnife";
    Image baseIcon;
    Sprite usableKnifeIcon;
    Sprite usedKnifeIcon;
    protected override void Init()
    {
        baseIcon = transform.Find("Knives/BaseIcon").GetComponent<Image>();
        usableKnifeIcon = Resources.Load<Sprite>(usableKnifeIconString);
        usedKnifeIcon = Resources.Load<Sprite>(usedKnifeIconString);
    }

    public List<Image> knives = new List<Image>();
    public void SetKnifeIcon(int knifeCount)
    {
        baseIcon.gameObject.SetActive(true);
        knives.ForEach(x => Destroy(x.gameObject));
        knives.Clear();
        for (int i = 0; i < knifeCount; i++)
        {
            var newKnifeIcon = Instantiate(baseIcon, baseIcon.transform.parent);
            newKnifeIcon.sprite = usableKnifeIcon;
            knives.Add(newKnifeIcon);
        }
        baseIcon.gameObject.SetActive(false);
    }

    internal void IncreaseUsedKnife(int usedKnifeCount)
    {
        knives[knives.Count - usedKnifeCount].sprite = usedKnifeIcon;
    }
}
