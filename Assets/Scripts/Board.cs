using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    const string stuckedKnifeString = "StuckedKnife";
    private const string appleParentGoString = "AppleParent";
    GameObject stuckedKnifeGo;
    void Start()
    {
        stuckedKnifeGo = (GameObject)Resources.Load(stuckedKnifeString);
        appleParentGo = (GameObject)Resources.Load(appleParentGoString);
        CreateApple();
    }

    int minAppleCount = 0;
    int maxAppleCount = 3;
    GameObject appleParentGo;
    void CreateApple()
    {
        var appleCount = Random.Range(minAppleCount, maxAppleCount + 1);
        for (int i = 0; i < appleCount; i++)
        {
            var newApple = Instantiate(appleParentGo, transform);
            newApple.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Knife") == false)
            return;

        // 나이프가 충돌
        ScoreUI.Instance.AddPoint(1);
        GameManager.Instance.KnifeHit();
        // 날라가는 칼 부수기
        Destroy(collision.collider.gameObject);
        // 아래위치에 박힌칼 생성, 부모는 보드
        var newKnife = Instantiate(stuckedKnifeGo);
        newKnife.transform.parent = transform;
    }
}
