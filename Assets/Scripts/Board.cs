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

        // �������� �浹
        ScoreUI.Instance.AddPoint(1);
        GameManager.Instance.KnifeHit();
        // ���󰡴� Į �μ���
        Destroy(collision.collider.gameObject);
        // �Ʒ���ġ�� ����Į ����, �θ�� ����
        var newKnife = Instantiate(stuckedKnifeGo);
        newKnife.transform.parent = transform;
    }
}
