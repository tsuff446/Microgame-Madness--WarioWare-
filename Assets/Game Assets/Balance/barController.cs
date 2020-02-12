using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    private int rotationRange;
    void Start()
    {
        globalVars.win = true;
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
        rotationRange = 45 + (int)globalVars.difficulty / 10;
        tm.Rotate(0,0, Random.Range(-rotationRange, rotationRange));
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddTorque(-1*Mathf.Sign(Input.GetAxis("Horizontal"))*20*rb.mass, ForceMode2D.Force);
            rb.angularDrag = .5f;
        }
        else
        {
            rb.angularDrag = 5;
        }
        if(globalVars.win == false)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
