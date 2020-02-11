using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongComputerPaddle : MonoBehaviour
{
    private Transform tm;
    private Rigidbody2D rb;
    private float paddleSpeed = 6f;
    private GameObject ball;
    private float verti;
    private Vector3 pos;
    void Start()
    {
        tm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        paddleSpeed *= ((globalVars.difficulty / 2) + .5f);
        ball = GameObject.Find("ball");
    }

    // Update is called once per frame
    void Update()
    {
        pos = tm.position;
        if(tm.position.y < ball.transform.position.y)
        {
            rb.velocity = new Vector3(0, paddleSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, -paddleSpeed, 0);
        }
        if (pos.y > 3.75f){
            tm.position = new Vector3(tm.position.x, 3.75f, 0f);
        }
        if (pos.y < -3.75f)
        {
            tm.position = new Vector3(tm.position.x, -3.75f, 0f);
        }
    }
}
