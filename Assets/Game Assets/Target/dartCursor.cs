using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartCursor : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    float hori;
    float vert;
    public float speed;
    Vector3 pos;
    private float generosity;
    public float sizex;
    public float sizey;
    public float startx;
    public float starty;
    bool shot;
    BoxCollider2D offset;
    float offsetx;
    float offsety;
    private AudioSource source;
    public AudioClip winning;
    public AudioClip losing;
    // Start is called before the first frame update
    void Start()
    {
        generosity = 1.51f * Mathf.Pow((1 / globalVars.difficulty),.3f);
        offset = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
        shot = false;
        pos = transform.position;
        transform.position = new Vector2(startx + Random.Range(-sizex, sizex), starty + Random.Range(-sizey, sizey));
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
            if (Input.GetButton("Action"))
            {
                shot = true;
                rb.velocity = new Vector2(0, 0);
                pos = transform.position;
                offsetx = offset.bounds.center.x;
                offsety = offset.bounds.center.y;
                if (Mathf.Pow((Mathf.Abs(offsetx - Target.pos.x)),2) + Mathf.Pow((Mathf.Abs(offsety - Target.pos.y)),2) < Mathf.Pow(generosity,2))
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
