using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongPlayerPaddle : MonoBehaviour
{
    private Transform tm;
    private Rigidbody2D rb;
    private float paddleSpeed = 6f;
    void Start()
    {
        tm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        paddleSpeed *= ((globalVars.difficulty / 2) + .5f);;
    }

    void Update()
    {
        rb.velocity = new Vector3(0, paddleSpeed * Input.GetAxis("Vertical"),0);
    }
}
