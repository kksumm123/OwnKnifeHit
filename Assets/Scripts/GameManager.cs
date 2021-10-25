using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int knifeCount = 10;
    void Start()
    {
        KnifeCountUI.Instance.SetKnifeIcon(knifeCount);
    }

    void Update()
    {
        
    }
}
