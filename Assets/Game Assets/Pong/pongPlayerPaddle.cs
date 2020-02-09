using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongPlayerPaddle : MonoBehaviour
{
    private Transform tm;
    private Rigidbody2D rb;
    private float paddleSpeed = 6f;
    private float verti;
    private Vector3 pos;
    void Start()
    {
        tm = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        paddleSpeed *= ((globalVars.difficulty / 2) + .5f);;
    }

    void Update()
    {
        pos = tm.position;
        verti = Input.GetAxis("Vertical");
        if (!(pos.y + (Mathf.Sign(verti) * .1f) > 3.75f) && !(pos.y + Mathf.Sign(verti) * .1f < -3.75f))
            rb.velocity = new Vector2(0, paddleSpeed * Input.GetAxis("Vertical"));
        else
            rb.velocity = Vector2.zero;
    }
}
