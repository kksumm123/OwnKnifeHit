using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameState
{
    None,
    Playing,
    GameOver,
    Loading,
}

public class GameManager : Singleton<GameManager>
{
    GameState m_gameState;
    public GameState GameState
    {
        get => m_gameState;
        set
        {
            if (m_gameState == value)
                return;

            Debug.Log($"GameState = {m_gameState} -> {value}");
            m_gameState = value;
        }
    }

    private const string bulletKnifeGoString = "BulletKnife";
    GameObject bulletKnifeGo;

    void Start()
    {
        GameState = GameState.Playing;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Knife"),
                                       LayerMask.NameToLayer("Knife"),
                                       true);
        bulletKnifeGo = (GameObject)Resources.Load(bulletKnifeGoString);

        InitKnifeCount();
        CreateKnife();
    }

    [SerializeField] int usedKnifeCount = 0;
    [SerializeField] int totalKnifeCount = 10;
    private void InitKnifeCount()
    {
        hitKnifeCount = 0;
        usedKnifeCount = 0;
        KnifeCountUI.Instance.SetKnifeIcon(totalKnifeCount);
    }
    private void IncreaseUsedKnife()
    {
        usedKnifeCount++;
        KnifeCountUI.Instance.IncreaseUsedKnife(usedKnifeCount);
    }

    void Update()
    {
        if (Input.anyKeyDown && isThrowable == true && GameState == GameState.Playing)
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

    #region Methods
    int hitKnifeCount = 0;
    internal void KnifeHit()
    {
        hitKnifeCount++;
        if (hitKnifeCount == totalKnifeCount)
        {
            // Į�� ���� �ȾѴ� ���� �������� ����
            // ���带 �μ��� �� ���带 �����´�
            StageManager.Instance.NextStage();

            // Į�� �ٽ� ��������� �Ѵ� (ī��Ʈ �ʱ�ȭ �� icon �� ����)
            InitKnifeCount();
            CreateKnife();
        }
    }
    internal void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    internal void GameOver()
    {
        GameState = GameState.GameOver;
        GameOverUI.Instance.ShowUI();
    }
    #endregion Methods
}

