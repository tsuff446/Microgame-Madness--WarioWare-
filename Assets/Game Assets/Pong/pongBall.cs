using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pongBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D otherBody;
    private Transform tm;
    public float speed;
    public AudioClip hitSound;
    private AudioSource source;
    private int firstVel;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Transform>();
        source = GetComponent<AudioSource>();
        speed = speed * ((globalVars.difficulty / 5) + .5f);
        rb = GetComponent<Rigidbody2D>();
        if(Random.Range(0.0f,1.0f) > .5f)
        {
            firstVel = 1;
        }
        else
        {
            firstVel = -1;
        }
        rb.velocity = new Vector3(-2*speed, firstVel * speed, 0);
        globalVars.win = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tm.position.x);
        if ((tm.position.x < -12) && globalVars.win == true)
        {
            GameObject.Find("playFailSound").GetComponent<AudioSource>().Play(0);
            PongGameMain.gameLost();
            Debug.Log("lose");
            this.gameObject.SetActive(false);
        }
        else if(tm.position.x > 12 && globalVars.win == true){
            PongGameMain.gameWon();
            this.gameObject.SetActive(false);

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //y velocity reversed when hitting player
        if (other.gameObject.CompareTag("Player"))
        {
            rb.velocity = rb.velocity * new Vector3(-1f, 1f, 1f);
            otherBody = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = rb.velocity + otherBody.velocity;
            source.PlayOneShot(hitSound);
        }
        // x velocity reversed when hitting wall
        if (other.gameObject.CompareTag("Wall"))
        {
            rb.velocity = rb.velocity * new Vector3(1f, -1f, 1f);
            source.PlayOneShot(hitSound);
        }

    }
}
