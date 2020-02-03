using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement2 : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5;
    private int jmp;
    // start is called before the first frame update
    void start()
    {
        rb = GetComponent<Rigidbody>();
        jmp = -5;
    }

    // update is called once per frame
    void update()
    {
        if (Input.GetKeyDown("space"))
        {
            jmp = 100;
        }
        else
        {
            jmp = -3;
        }
        rb.velocity = new Vector3(Input.GetAxis("horizontal"), jmp, 0);
    }
}
