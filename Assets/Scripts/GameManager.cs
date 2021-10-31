using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string bulletKnifeGoString = "BulletKnife";
    GameObject bulletKnifeGo;
    [SerializeField] int knifeCount = 10;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Knife"),
                                       LayerMask.NameToLayer("Knife"),
                                       true);
        KnifeCountUI.Instance.SetKnifeIcon(knifeCount);
        bulletKnifeGo = (GameObject)Resources.Load(bulletKnifeGoString);

        CreateKnife();
    }

    void Update()
    {
        if (Input.anyKeyDown && isThrowable == true)
            StartCoroutine(ClickedCo());
    }

    bool isThrowable = false;
    IEnumerator ClickedCo()
    {
        isThrowable = false;
        ThrowKnife();
        yield return new WaitForSeconds(0.1f);
        CreateKnife();
    }

    GameObject currentKnife;
    void CreateKnife()
    {
        currentKnife = Instantiate(bulletKnifeGo);
        currentKnife.GetComponent<FlyingKnife>().enabled = false;
        isThrowable = true;
    }
    void ThrowKnife()
    {
        currentKnife.GetComponent<FlyingKnife>().enabled = true;
    }
}

