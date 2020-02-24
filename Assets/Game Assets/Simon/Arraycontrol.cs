using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arraycontrol : MonoBehaviour
{
    int length;
    static public int[] masterarray;
    int count;
    private AudioSource source;
    public AudioClip good;
    public AudioClip bad;
    public AudioClip cheer;
    bool done;
    float time;
    bool go;
    bool readyup;
    bool readydown;
    bool readyleft;
    bool readyright;
    public static float totaltime;
    float gen;
    float startingtime;
    float startingwait;

    // Start is called before the first frame update
    void Start()
    {
        if (globalVars.difficulty > 8)
        {
            length = 9;
        }
        else
        {
            length = Mathf.FloorToInt(globalVars.difficulty * .6f + 3);
        }
        masterarray = new int[length];
        for(int i = 0; i < length; ++i)
        {
            masterarray[i] = Random.Range(1, 5);
        }
        count = 0;
        source = GetComponent<AudioSource>();
        done = false;
        time = 0;
        go = false;
        readyup = true;
        readydown = true;
        readyleft = true;
        readyright = true;
        totaltime = 3;
        gen = .4f;
        startingtime = 0;
        startingwait = 0.4f;
    }
        
    // Update is called once per frame
    void Update()
    {
        startingtime += Time.deltaTime;
        if (startingtime > startingwait)
        {
            time += Time.deltaTime;
            if (time > totaltime)
            {
                go = true;
            }
            if ((!done) && go)
            {
                if ((Input.GetAxis("Vertical") > gen) && readyup && (count < length) && !done)
                {
                    if (masterarray[count] == 1)
                    {
                        source.PlayOneShot(good, 1f);
                        readyup = false;
                    }
                    else
                    {
                        source.PlayOneShot(bad, 1f);
                        SimonMain.gameLost();
                        done = true;
                    }
                    ++count;
                }
                if ((Input.GetAxis("Horizontal") < -gen) && readyleft && (count < length) && !done)
                {
                    if (masterarray[count] == 2)
                    {
                        source.PlayOneShot(good, 1f);
                        readyleft = false;
                    }
                    else
                    {
                        source.PlayOneShot(bad, 1f);
                        SimonMain.gameLost();
                        done = true;
                    }
                    ++count;
                }
                if ((Input.GetAxis("Horizontal") > gen) && readyright && (count < length) && !done)
                {
                    if (masterarray[count] == 3)
                    {
                        source.PlayOneShot(good, 1f);
                        readyright = false;
                    }
                    else
                    {
                        source.PlayOneShot(bad, 1f);
                        SimonMain.gameLost();
                        done = true;
                    }
                    ++count;
                }
                if ((Input.GetAxis("Vertical") < -gen) && readydown && (count < length) && !done)
                {
                    if (masterarray[count] == 4)
                    {
                        source.PlayOneShot(good, 1f);
                        readydown = false;
                    }
                    else
                    {
                        source.PlayOneShot(bad, 1f);
                        SimonMain.gameLost();
                        done = true;
                    }
                    ++count;
                }
                if (Input.GetAxis("Vertical") > -gen)
                {
                    readydown = true;
                }
                if (Input.GetAxis("Vertical") < gen)
                {
                    readyup = true;
                }
                if (Input.GetAxis("Horizontal") > -gen)
                {
                    readyleft = true;
                }
                if (Input.GetAxis("Horizontal") < gen)
                {
                    readyright = true;
                }
                if (count >= length && !done)
                {
                    source.PlayOneShot(cheer, 1f);
                    SimonMain.gameWon();
                    done = true;
                }
            }
        }
    }
}
