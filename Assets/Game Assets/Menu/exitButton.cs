using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class exitButton : MonoBehaviour
{
    private bool controllerConnected;
    private SpriteRenderer sp;
    public GameObject cursor;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        controllerConnected = Convert.ToBoolean(Input.GetJoystickNames().Length);
    }

    bool checkCursorCollision()
    {
        if (cursor.transform.position.x < this.transform.position.x + sp.bounds.size.x / 2 && cursor.transform.position.x > this.transform.position.x - sp.bounds.size.x / 2)
            if (cursor.transform.position.y < this.transform.position.y + sp.bounds.size.y / 2 && cursor.transform.position.y > this.transform.position.y - sp.bounds.size.y / 2)
                return true;
        return false;
    }
    void Update()
    {
        if (checkCursorCollision() && (Input.GetAxis("Action") > 0 || Input.GetMouseButtonDown(0)))
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
    }
}
