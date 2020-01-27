﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tm;
    private bool down = false;
    private float count = 0;
    private GameObject pumpTop;
    private float topHeight;
    private float pumpSpeed;
    private int maxPump;
    private int minPump = 15;

    private AudioSource balloonAudio;
    public AudioClip pumpSound;
    public AudioClip pop;
    void Start()
    {
        pumpSpeed = 5f;
        maxPump = minPump + (int)globalVars.difficulty * 5;
        tm = GetComponent<Transform>();
        pumpTop = GameObject.Find("pump").transform.GetChild(0).gameObject;
        topHeight = pumpTop.GetComponent<SpriteRenderer>().bounds.size.y;
        balloonAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") < 0 && !down && pumpTop.transform.localPosition.y == 0 && !globalVars.win && !bombTimer.externEnd)
        {
            down = true;
            count++;
            tm.localScale += new Vector3(count / 10, count / 10, 1);
            tm.position = tm.position + new Vector3(0, count / 20, 0);
            pumpTop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -pumpSpeed);
            balloonAudio.PlayOneShot(pumpSound);
        }
        else if (Input.GetAxis("Vertical") > 0 && down && pumpTop.transform.localPosition.y == -topHeight * 1 / 4 && !globalVars.win && !bombTimer.externEnd)
        {
            down = false;
            pumpTop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, pumpSpeed);
        }

        if (pumpTop.transform.localPosition.y > 0)
        {
            pumpTop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pumpTop.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (pumpTop.transform.localPosition.y < -topHeight * 1 / 4)
        {
            pumpTop.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            pumpTop.transform.localPosition = new Vector3(0, -topHeight * 1 / 4, 0);
        }

        if(count >= maxPump && !globalVars.win && !bombTimer.externEnd)
        {
            BalloonGameMain.gameWon();
            GetComponent<SpriteRenderer>().enabled = false;
            balloonAudio.PlayOneShot(pop);
        }
    }
}