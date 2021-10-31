using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    const string stuckedKnifeString = "StuckedKnife";
    GameObject stuckedKnifeGo;
    void Start()
    {
        stuckedKnifeGo = (GameObject)Resources.Load(stuckedKnifeString);
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Knife") == false)
            return;

        // 나이프가 충돌
        print("아얏 아포 힝");
        // 날라가는 칼 부수기
        Destroy(collision.collider.gameObject);
        // 아래위치에 박힌칼 생성, 부모는 보드
        var newKnife = Instantiate(stuckedKnifeGo);
        newKnife.transform.parent = transform;
    }
}
