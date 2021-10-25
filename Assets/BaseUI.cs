using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_instance;
    public static T Instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<T>();

            return m_instance;
        }
    }
    protected void OnDestroy()
    {
        m_instance = null;
    }
    protected void Awake()
    {
        if (gameObject.activeSelf == false)
            gameObject.SetActive(true);

        transform.SetAsLastSibling();
    }
    protected void ShowUI()
    {
        gameObject.SetActive(true);
    }
    protected void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
