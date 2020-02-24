using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    //idnum should be set to 1-8 for each of the 8 spikes on screen
    public int idnum;
    //spiked is true if the spikes have risen
    public static bool spiked;
    public Vector3 pos;
    //heightchange is the change in y the spikes need when they go off
    public float heightchange;
    // Start is called before the first frame update
    private AudioSource source;
    public AudioClip spikenoise;
    public float heightstart;
    public float center;
    public float spacing;
    public float totalspikes;
    public SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        spiked = false;
        pos = new Vector3((idnum - (totalspikes/2) - 0.5f) * spacing + center, heightstart, 0);
        transform.position = pos;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((bombTimer.timeLeft < 1f)&&(!(pos.x==Arrow.pos.x)))
        {
            rend.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, pos.y + heightchange, 0),.8f);
            // Prevents sound from being played multiple times
            if (!spiked)
            {
                source.PlayOneShot(spikenoise, 1f);
            }
            spiked = true;
        }
    }
}
