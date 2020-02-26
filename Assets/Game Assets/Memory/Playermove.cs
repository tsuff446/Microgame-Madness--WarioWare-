using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    Vector2 pos;
    int movesright;
    int movesdown;
    bool readyup;
    bool readydown;
    bool readyleft;
    bool readyright;
    float gen;
    bool beginning;
    private AudioSource source;
    public AudioClip good;
    public AudioClip bad;
    bool found1;
    bool found2;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        readyup = true;
        readydown = true;
        readyleft = true;
        readyright = true;
        gen = 0.4f;
        beginning = true;
        found1 = false;
        found2 = false;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            if (beginning)
            {
                movesright = Mathf.FloorToInt(Shuffle.length / 2);
                movesdown = Mathf.FloorToInt(Shuffle.height / 2);
                beginning = false;
            }
            pos = new Vector2(-Shuffle.boardwidth / 2 + Shuffle.xspacing * movesright, Shuffle.boardheight / 2 - Shuffle.yspacing * movesdown);
            transform.position = pos;
            if (Input.GetAxis("Horizontal") < gen)
            {
                readyright = true;
            }
            if (Input.GetAxis("Vertical") < gen)
            {
                readyup = true;
            }
            if (Input.GetAxis("Horizontal") > -gen)
            {
                readyleft = true;
            }
            if (Input.GetAxis("Vertical") > -gen)
            {
                readydown = true;
            }
            if (Input.GetAxis("Horizontal") > gen && movesright < Shuffle.length - 1 && readyright)
            {
                ++movesright;
                readyright = false;
            }
            if (Input.GetAxis("Horizontal") < -gen && movesright > 0 && readyleft)
            {
                --movesright;
                readyleft = false;
            }
            if (Input.GetAxis("Vertical") > gen && movesdown > 0 && readyup)
            {
                --movesdown;
                readyup = false;
            }
            if (Input.GetAxis("Vertical") < -gen && movesdown < Shuffle.height - 1 && readydown)
            {
                ++movesdown;
                readydown = false;
            }
            if (Input.GetButton("Action"))
            {
                if (new Vector2(transform.position.x, transform.position.y) == Shuffle.dupeposition1)
                {
                    if (!found1)
                    {
                        source.PlayOneShot(good, 1f);
                        found1 = true;
                    }
                    if (found1 && found2)
                    {
                        Memorymain.gameWon();
                        done = true;
                    }

                }
                else if (new Vector2(transform.position.x, transform.position.y) == Shuffle.dupeposition2)
                {
                    if (!found2)
                    {
                        source.PlayOneShot(good, 1f);
                        found2 = true;
                    }
                    if (found1 && found2)
                    {
                        Memorymain.gameWon();
                        done = true;
                    }
                }
                else
                {
                    source.PlayOneShot(bad, 1f);
                    Memorymain.gameLost();
                    done = true;
                }
            }
        }
        
    }
}
