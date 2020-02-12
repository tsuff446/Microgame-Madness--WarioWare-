﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump3 : MonoBehaviour
{
    Rigidbody rb;
    bool isgrounded = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, 8);
        
        }
        rb.velocity = new Vector2(5 * Input.GetAxis("Horizontal"), rb.velocity.y);
    }

    //make sure u replace "floor" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "wall"|| theCollision.gameObject.name == "Plat1"||theCollision.gameObject.name == "Plat2" || theCollision.gameObject.name == "Plat3")
        {
            isgrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "wall" || theCollision.gameObject.name == "Plat1" || theCollision.gameObject.name == "Plat2" || theCollision.gameObject.name == "Plat3")
        {
            isgrounded = false;
        }
    }
}