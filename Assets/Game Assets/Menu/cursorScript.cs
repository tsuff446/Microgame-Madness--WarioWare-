using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool controllerConnected;
    private float width;
    private float height;
    void Start()
    {
        Cursor.visible = false;
        controllerConnected = Convert.ToBoolean(Input.GetJoystickNames().Length);
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        Camera orthoCam = Camera.main;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = orthoCam.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        width = camWidth;
        height = 2.0f * camHalfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        controllerConnected = Convert.ToBoolean(Input.GetJoystickNames().Length);
        this.transform.position += new Vector3(Input.GetAxis("Horizontal") / 2, Input.GetAxis("Vertical") / 2, 0f);
        if (!controllerConnected)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position += new Vector3(0, 0, 5f);
        }
        
        if (this.transform.position.x > width / 2)
            this.transform.position = new Vector3(width / 2, transform.position.y, transform.position.z);
        if (this.transform.position.x < -width / 2)
            this.transform.position = new Vector3(-width / 2, transform.position.y, transform.position.z);
        if (this.transform.position.y > height / 2)
            this.transform.position = new Vector3( transform.position.x, height / 2, transform.position.z);
        if (this.transform.position.y < -height / 2)
            this.transform.position = new Vector3( transform.position.x, -height / 2, transform.position.z);
    }
}
