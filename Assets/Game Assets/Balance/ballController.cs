using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    void Start()
    {
        globalVars.win = true;
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
        rb.mass = 1f - globalVars.difficulty / 50;
    }

    void Update()
    {
        if((tm.position.y < -7 || tm.position.x > 11 || tm.position.x < -11) && globalVars.win)
        {
            balanceMain.gameLost();
            GetComponent<AudioSource>().Play(0);
        }
    }
}
