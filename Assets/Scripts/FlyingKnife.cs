using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKnife : MonoBehaviour
{
    [SerializeField] float speed = 25f;
    Vector2 moveDirection = new Vector2(0, 1);
    private void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}
