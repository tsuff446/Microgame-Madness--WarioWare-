using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public int idnum;
    float hori;
    float vert;
    Color col;
    SpriteRenderer sr;
    float time;
    int count;
    float spacing;
    float length;
    bool now;
    public static float totaltime;
    float gen;
    private AudioSource source;
    public AudioClip good;
    bool freeze;
    float startingtime;
    float startingwait;
    bool played;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SpriteRenderer>().material.color;
        source = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        time = 0;
        count = 0;
        if (globalVars.difficulty > 8)
        {
            length = 9;
        }
        else
        {
            length = Mathf.FloorToInt(globalVars.difficulty * .6f + 3);
        }
        totaltime = 3;
        spacing = totaltime / length;
        now = true;
        gen = .4f;
        
        freeze = false;
        startingtime = 0;
        startingwait = 0.4f;
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        startingtime += Time.deltaTime;
        if (startingtime > startingwait)
        {
            if (idnum == 1 && !played)
            {
                source.PlayOneShot(good, 1f);
                played = true;
            }
            if ((time > spacing * (count + 1)) && (count < (length - 1)))
            {
                if (idnum == 1 && (!freeze))
                {
                    source.PlayOneShot(good, 1f);
                }
                ++count;
            }
            time += Time.deltaTime;
            //GetComponent<SpriteRenderer>().material.color = col;
            if (time > totaltime)
            {
                freeze = true;
                if (now)
                {
                    sr.material.color = col;
                    now = false;
                }
                hori = Input.GetAxis("Horizontal");
                vert = Input.GetAxis("Vertical");
            }
            else
            {
                if ((time > spacing * (count + .7f)))
                {
                    vert = 0;
                    hori = 0;
                    sr.material.color = col;
                }
                else
                {
                    if (Arraycontrol.masterarray[count] == 1)
                    {
                        vert = 1;
                        hori = 0;
                    }
                    if (Arraycontrol.masterarray[count] == 2)
                    {
                        hori = -1;
                        vert = 0;
                    }
                    if (Arraycontrol.masterarray[count] == 3)
                    {
                        hori = 1;
                        vert = 0;
                    }
                    if (Arraycontrol.masterarray[count] == 4)
                    {
                        vert = -1;
                        hori = 0;
                    }
                }
            }
            if (vert > gen)
            {
                if (idnum == 1)
                {

                    sr.material.color = new Color(1, 200, 200, 1.0f);
                }
                else
                {
                    sr.material.color = col;
                }
            }
            if (hori > gen)
            {
                if (idnum == 3)
                {

                    sr.material.color = new Color(200, 200, 1, 1.0f);
                }
                else
                {
                    sr.material.color = col;
                }
            }
            if (vert < -gen)
            {
                if (idnum == 4)
                {

                    sr.material.color = new Color(1, 1, 200, 1.0f);
                }
                else
                {
                    sr.material.color = col;
                }
            }
            if (hori < -gen)
            {
                if (idnum == 2)
                {

                    sr.material.color = new Color(200, 1, 200, 1.0f);
                }
                else
                {
                    sr.material.color = col;
                }
            }
        }
    }
}
