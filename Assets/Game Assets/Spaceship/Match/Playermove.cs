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
    bool done;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        readyup = true;
        readydown = true;
        readyleft = true;
        readyright = true;
        gen = 0.1f;
        beginning = true;
        done = false;
        rend = GetComponent<SpriteRenderer>();
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
                    source.PlayOneShot(good, 1f);
                    Memorymain.gameWon();
                    done = true;
                    GameObject go = new GameObject("New");
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = rend.sprite;
                    renderer.sortingOrder = -1;
                    go.transform.localScale = new Vector2(1.5f, 1.5f);
                    Instantiate(go, Shuffle.dupeposition1, new Quaternion(0, 0, 0, 0));
                    Instantiate(go, Shuffle.dupeposition2, new Quaternion(0, 0, 0, 0));
                    Destroy(go);

                }
                else if (new Vector2(transform.position.x, transform.position.y) == Shuffle.dupeposition2)
                {

                    source.PlayOneShot(good, 1f);
                    Memorymain.gameWon();
                    done = true;
                    GameObject go = new GameObject("New");
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = rend.sprite;
                    renderer.sortingOrder = -1;
                    go.transform.localScale = new Vector2(1.5f, 1.5f);
                    Instantiate(go, Shuffle.dupeposition1, new Quaternion(0, 0, 0, 0));
                    Instantiate(go, Shuffle.dupeposition2, new Quaternion(0, 0, 0, 0));
                    Destroy(go);

                }
                else
                {
                    source.PlayOneShot(bad, 1f);
                    Memorymain.gameLost();
                    done = true;
                    GameObject go = new GameObject("New");
                    SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
                    renderer.sprite = rend.sprite;
                    renderer.sortingOrder = -1;
                    go.transform.localScale = new Vector2(1.5f, 1.5f);
                    Instantiate(go, Shuffle.dupeposition1, new Quaternion(0, 0, 0, 0));
                    Instantiate(go, Shuffle.dupeposition2, new Quaternion(0, 0, 0, 0));
                    Destroy(go);
                }
            }
        }
        
    }
}
