using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() => instance = this;

    private const string bulletKnifeGoString = "BulletKnife";
    GameObject bulletKnifeGo;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Knife"),
                                       LayerMask.NameToLayer("Knife"),
                                       true);
        bulletKnifeGo = (GameObject)Resources.Load(bulletKnifeGoString);

        InitKnifeCount();
        CreateKnife();
    }

    internal void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    [SerializeField] int usedKnifeCount = 0;
    [SerializeField] int totalKnifeCount = 10;
    private void InitKnifeCount()
    {
        KnifeCountUI.Instance.SetKnifeIcon(totalKnifeCount);
    }
    private void IncreaseUsedKnife()
    {
        usedKnifeCount++;
        KnifeCountUI.Instance.IncreaseUsedKnife(usedKnifeCount);
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
        IncreaseUsedKnife();
        yield return new WaitForSeconds(0.1f);

        if (usedKnifeCount < totalKnifeCount)
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

