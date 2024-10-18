using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Log : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 6f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.left * speed;
    }
}
