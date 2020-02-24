using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static Vector3 pos;
    public float positionvalue;
    //targetheight is the y value you want the arrow to be at
    public float targetheight;
    //spacing is the distance between the possible positions for the arrow, there is 8 positions evenly divided
    public float spacing;
    //center is the x value of the center of the 8 positions, not an actual position, between positions 4 and 5
    public float center;
    bool done;
    float time;
    private AudioSource source;
    public AudioClip arrownoise;
    // Start is called before the first frame update
    bool move;
    float ch;
    private Rigidbody2D rb;
    public SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        done = false;
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        positionvalue = Random.Range(1, 8) - 4.5f;
        if (globalVars.difficulty > 6)
        {
            rend.enabled = true;
            time = 2f;
            move = true;
            ch = Random.Range(-globalVars.difficulty, globalVars.difficulty) * 1.4f;
            pos = new Vector3((float)((spacing * (double)positionvalue) + center) + ch, targetheight, 0);
            transform.position = pos;
        }
        else
        {
            time = 5f - globalVars.difficulty / 2;
            move = false;
        }
    }
    private void Update()
    {
        if ((bombTimer.timeLeft < time)&&(!done))
        {
            rend.enabled = true;
            if (move)
            {
                rb.velocity = new Vector2(-ch*5,0);
                pos = transform.position;
                if( ((pos.x > (float)((spacing * (double)positionvalue) + center)) &&
                    (ch < 0)) ||
                    ((ch > 0) &&
                    (pos.x < (float)((spacing * (double)positionvalue) + center))) )
                {
                    source.PlayOneShot(arrownoise, 1f);
                    pos = new Vector3((float)((spacing * (double)positionvalue) + center), targetheight, 0);
                    rb.velocity = new Vector2(0, 0);
                    transform.position = pos;
                    done = true;
                }
            }
            else
            {
                source.PlayOneShot(arrownoise, 1f);
                pos = new Vector3((float)((spacing * (double)positionvalue) + center), targetheight, 0);
                transform.position = pos;
                done = true;
            }
            
            
        }
    }
    
}
