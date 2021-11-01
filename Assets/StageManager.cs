using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    private const string boardGoString = "Board";

    // ���������� ���۵Ǹ� ���带 ���������
    int stage = 0;
    GameObject boardGo;
    void Start()
    {
        boardGo = (GameObject)Resources.Load(boardGoString);
        CreateNewBoard();
    }

    void NextStage()
    {
        GameManager.Instance.GameState = GameState.Loading;
        StageUI.Instance.WhiteScreen();
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