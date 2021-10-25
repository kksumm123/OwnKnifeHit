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
        KnifeCountUI.Instance.SetKnifeIcon(knifeCount);
        bulletKnifeGo = (GameObject)Resources.Load(bulletKnifeGoString);
    }

    void Update()
    {
        if (Input.anyKeyDown)
            Instantiate(bulletKnifeGo);
    }
}
