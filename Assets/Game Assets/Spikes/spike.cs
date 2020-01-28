﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    //spiked is true if the spikes have risen
    public static bool spiked;
    public Vector3 pos;
    //heightchange is the change in y the spikes need when they go off
    public float heightchange;
    // Start is called before the first frame update
    private AudioSource source;
    public AudioClip spikenoise;
    void Start()
    {
        spiked = false;
        pos = transform.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((bombTimer.timeLeft < 1f)&&(!(pos.x==Arrow.pos.x)))
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, pos.y + heightchange, 0),.8f);
            spiked = true;
            source.PlayOneShot(spikenoise, .1f);
        }
    }
}
