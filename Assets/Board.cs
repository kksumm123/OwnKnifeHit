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

        // �������� �浹
        print("�ƾ� ���� ��");
        // ���󰡴� Į �μ���
        Destroy(collision.collider.gameObject);
        // �Ʒ���ġ�� ����Į ����, �θ�� ����
        var newKnife = Instantiate(stuckedKnifeGo);
        newKnife.transform.parent = transform;
    }
}
