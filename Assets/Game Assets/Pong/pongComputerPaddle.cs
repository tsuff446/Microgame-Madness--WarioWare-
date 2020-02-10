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
            verti = 1;
        }
        else
        {
            rb.velocity = new Vector3(0, -paddleSpeed, 0);
            verti = -1;
        }
        if ((pos.y + (Mathf.Sign(verti) * .1f) > 3.75f) || (pos.y + Mathf.Sign(verti) * .1f < -3.75f))
            rb.velocity = -rb.velocity;
        
            
    }
}
