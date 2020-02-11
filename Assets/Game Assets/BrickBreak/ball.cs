using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private Rigidbody2D otherBody;
    private Transform tm;
    private float speed;
    bool wait;
    public AudioClip paddleHit;
    public AudioClip brickHit;
    public AudioClip greenBrickHit;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        tm = GetComponent<Transform>();
        float xOffset = Random.Range(-1f,1f);
        tm.position += new Vector3(xOffset, 0f, 0f);
        Vector2 initVeloc;
        initVeloc = new Vector2((xOffset*-speed)/1.84f, -speed);
        source = GetComponent<AudioSource>();
        speed = speed * ((globalVars.difficulty / 3) + .5f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initVeloc;
    }

    // Update is called once per frame
    void Update()
    {
        if((tm.position.y < -5 || tm.position.y > 5 ) && globalVars.win == false)
        {
            GameObject.Find("playFailSound").GetComponent<AudioSource>().Play(0);
            BrickBreakMain.gameLost();
            this.gameObject.SetActive(false);
        }
        wait = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //y velocity reversed when hitting player
        if (other.gameObject.CompareTag("Player"))
        {
            float brickWidth = other.gameObject.GetComponent<SpriteRenderer>().size.x / 2;
            float brickX = other.gameObject.transform.position.x;
            float ballX = tm.position.x;
            Vector2 reflect;
            if (ballX < brickX - brickWidth * .9 || ballX > brickX + brickWidth * .9)
            {
                reflect = new Vector2(-1f, -1f);
            }
            else
            {
                reflect = new Vector2(1f, -1f);
            }

            rb.velocity = rb.velocity * reflect;
            otherBody = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = rb.velocity + otherBody.velocity;
            source.PlayOneShot(paddleHit);
        }
        // x velocity reversed when hitting wall
        if (other.gameObject.CompareTag("Wall"))
        {
            rb.velocity = rb.velocity * new Vector3(-1f, 1f, 1f);

        }

        if (other.gameObject.CompareTag("Collectible"))
        {
            BrickBreakMain.gameWon();
            other.gameObject.SetActive(false);
            source.PlayOneShot(greenBrickHit);

        }
        // bool wait makes sure if the ball hits 2 bricks the velocity doesn't flip twice
        if (other.gameObject.CompareTag("Brick"))
        {
            if (!wait)
            {
                rb.velocity = rb.velocity * new Vector3(1f, -1f, 1f);
                wait = true;
            }
            source.PlayOneShot(brickHit);
            other.gameObject.SetActive(false);
        }
    }
}
