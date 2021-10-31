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
        isThrowing = true;
    }
    bool isThrowing = false;
    void Update()
    {
        if (isThrowing)
            transform.Translate(speed * Time.deltaTime * moveDirection);
    }
    /*
    1. 나이프끼리는 충돌안되게
    2. 던지는 딜레이
    3. 던지는 나이프, 박힌 나이프 태그 구별
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
    }
}
