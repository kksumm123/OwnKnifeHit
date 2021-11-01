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
    // 초기 시작 토탈 카운트 7, 스테이지 5개 넘어갈 때마다 1씩 증가
    [SerializeField] int totalKnifeCount = 7;
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
    internal void IncreaseTotalKnifeCount()
    {
        // 스테이지가 5의 배수일 때, 토탈 나이프 카운트 1 증가
        totalKnifeCount++;
    }

    int hitKnifeCount = 0;
    internal void KnifeHit()
    {
        hitKnifeCount++;
        if (hitKnifeCount == totalKnifeCount)
        {
            // 칼을 전부 꽂앗다 다음 스테이지 가자
            // 보드를 부수고 새 보드를 가져온다
            StageManager.Instance.NextStage();

            // 칼을 다시 충전해줘야 한다 (카운트 초기화 및 icon 재 설정)
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

