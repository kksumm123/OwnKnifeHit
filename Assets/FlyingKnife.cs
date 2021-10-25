using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingKnife : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    Vector2 moveDirection = new Vector2(0, 1);
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * moveDirection);
    }
}
