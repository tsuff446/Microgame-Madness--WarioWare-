using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    float hori;
    float vert;
    public float speed;
    float xdrift;
    float ydrift;
    public float xstart;
    public float ystart;
    private AudioSource aa;
    public AudioClip explode;
    public AudioClip zoom;
    bool done;
    public Sprite sp;
    Vector3 pos;
    float diff;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        aa = GetComponent<AudioSource>();
        transform.position = new Vector2(xstart, ystart);
        globalVars.win = true;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        diff = globalVars.difficulty;
        if(globalVars.difficulty > 12)
        {
            diff = 12;
        }
        xdrift = Random.Range(-diff,diff);
        ydrift = Random.Range(-diff,diff);
        aa.PlayOneShot(zoom);
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            hori = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(hori * speed + xdrift / 2.5f, vert * speed + ydrift / 2.5f);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = pos;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Asteroid" && !done)
        {
            SSMain.gameLost();
            sr.sprite = sp;
            pos = transform.position;
            transform.localScale = new Vector2(.5f,.5f);
            aa.PlayOneShot(explode);
            done = true;
        }

    }
}
