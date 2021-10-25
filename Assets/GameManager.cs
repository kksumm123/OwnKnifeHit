using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int knifeCount = 8;
    void Start()
    {
        KnifeCountUI.Instance.SetKnifeIcon(knifeCount);
    }

    void Update()
    {
        
    }
}
