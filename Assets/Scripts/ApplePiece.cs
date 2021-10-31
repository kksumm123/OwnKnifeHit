using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePiece : MonoBehaviour
{
    Rigidbody2D rigid;
    [SerializeField] float dirX = 0.5f;
    [SerializeField] float forceValue = 300;
    void Start()
    {
        Destroy(gameObject, 3);
        rigid = GetComponent<Rigidbody2D>();
        var dir = new Vector2(Random.Range(-dirX, dirX), 1);
        rigid.AddForce(dir * forceValue, ForceMode2D.Force);
    }
}
