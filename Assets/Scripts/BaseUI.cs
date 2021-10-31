using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI<T> : Singleton<T> where T : MonoBehaviour
{
    protected void Awake()
    {
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);

        transform.SetAsLastSibling();

        Init();
    }

    protected virtual void Init() { }

    protected void ShowUI()
    {
        gameObject.SetActive(true);
    }
    protected void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
