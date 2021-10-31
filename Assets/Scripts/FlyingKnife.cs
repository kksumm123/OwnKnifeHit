using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKnife : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    Vector2 moveDirection = new Vector2(0, 1);
    Rigidbody2D rigid;
    private void Start()
    {
        Destroy(gameObject, 5);
        rigid = GetComponent<Rigidbody2D>();
        applePieceGo = (GameObject)Resources.Load(applePieceGoString);
        Debug.Assert(applePieceGo != null, "�̰� null �Ǹ� �ȵ�");
        isThrowing = true;
    }
    bool isThrowing = false;
    void Update()
    {
        if (isThrowing)
            transform.Translate(speed * Time.deltaTime * moveDirection);
    }
    /*
    1. ������������ �浹�ȵǰ�
    2. ������ ������
    3. ������ ������, ���� ������ �±� ����
     */
    float bounceForceValue = 300f;
    float torqueValue = 30f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("StuckedKnife"))
        {
            isThrowing = false;
            rigid.AddForce(Vector2.down * bounceForceValue, ForceMode2D.Force);
            rigid.AddTorque(Random.Range(-torqueValue, torqueValue));
        }
        else if (collision.collider.CompareTag("Apple"))
        {
            print("��� ����Ʈ ȹ��");
            CreateApplePiece(collision.collider.transform);
            Destroy(collision.gameObject);
        }
    }

    private const string applePieceGoString = "ApplePiece";
    GameObject applePieceGo;
    private void CreateApplePiece(Transform appleSprite)
    {
        for (int i = 0; i < 2; i++)
        {
            var newApplePiece = Instantiate(applePieceGo);
            newApplePiece.transform.position = appleSprite.position;
        }
    }
}
