using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    float hori;
    float vert;
    public float speed;
    Vector3 pos;
    public float generosity;
    public float sizex;
    public float sizey;
    bool shot;
    private AudioSource source;
    public AudioClip winning;
    public AudioClip losing;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        shot = false;
        pos = transform.position;
        transform.position = new Vector2(pos.x + Random.Range(-sizex, sizex), pos.y + Random.Range(-sizey, sizey));
        globalVars.win = false;
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shot)
        {
            hori = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(hori * speed, vert * speed);
            if (Input.GetButton("Jump"))
            {
                shot = true;
                rb.velocity = new Vector2(0, 0);
                pos = transform.position;
                if ((Mathf.Abs(pos.x - Target.pos.x) < generosity) && (Mathf.Abs(pos.y - Target.pos.y) < generosity))
                {
                    source.PlayOneShot(winning, 1f);
                    TargetMain.gameWon();
                }
                else
                {
                    source.PlayOneShot(losing, 1f);
                    TargetMain.gameLost();
                }
            }
        }
        
    }
}
