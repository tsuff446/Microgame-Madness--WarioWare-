using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arraycontrol : MonoBehaviour
{
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
    float gen;
    float startingtime;

    // Start is called before the first frame update
    void Start()
    {
        masterarray = new int[Buttons.length];
        for(int i = 0; i < Buttons.length; ++i)
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
        gen = .4f;
        startingtime = 0;
    }
        
    // Update is called once per frame
    void Update()
    {
        startingtime += Time.deltaTime;
        if (startingtime > Buttons.startingwait)
        {
            time += Time.deltaTime;
            if (time > Buttons.totaltime)
            {
                go = true;
            }
            if ((!done) && go)
            {
                if ((Input.GetAxis("Vertical") > gen) && readyup && (count < Buttons.length) && !done)
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
                if ((Input.GetAxis("Horizontal") < -gen) && readyleft && (count < Buttons.length) && !done)
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
                if ((Input.GetAxis("Horizontal") > gen) && readyright && (count < Buttons.length) && !done)
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
                if ((Input.GetAxis("Vertical") < -gen) && readydown && (count < Buttons.length) && !done)
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
                if (count >= Buttons.length && !done)
                {
                    source.PlayOneShot(cheer, 1f);
                    SimonMain.gameWon();
                    done = true;
                }
            }
        }
    }
}
