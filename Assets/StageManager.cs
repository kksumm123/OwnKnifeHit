using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    private const string boardGoString = "Board";

    // 스테이지가 시작되면 보드를 만들어주자
    GameObject boardGo;
    void Start()
    {
        boardGo = (GameObject)Resources.Load(boardGoString);
        CreateNewBoard();
    }

    public void NextStage()
    {
        StageUI.Instance.IncreaseStageValue();
        DestroyBoard();
        GameManager.Instance.GameState = GameState.Loading;
        StageUI.Instance.WhiteScreen();
        CreateNewBoard();
    }

    GameObject currentBoard;
    void CreateNewBoard()
    {
        currentBoard = Instantiate(boardGo);
    }
    public void DestroyBoard()
    {
        Destroy(currentBoard);
    }
}