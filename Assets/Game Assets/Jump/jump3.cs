using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump3 : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            isGrounded = false;
        }
        rb.velocity = new Vector2(5*Input.GetAxis("Horizontal"),rb.velocity.y);
    }
}