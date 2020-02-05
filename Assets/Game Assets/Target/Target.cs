using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    static public Vector2 pos;
    private Rigidbody2D rb;
    private Transform tm;
    public float speed;
    public float sizex;
    public float sizey;
    public float startx;
    public float starty;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        transform.position = new Vector2(startx + Random.Range(-sizex,sizex), starty + Random.Range(-sizey,sizey));
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
        rb.velocity = new Vector2(globalVars.difficulty * .25f * speed * (Random.Range(1, 3) * 2 - 3), globalVars.difficulty * .25f * speed * (Random.Range(1, 3) * 2 - 3));
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(0, 0);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Horizontal wall")
        {
            rb.velocity = new Vector2(rb.velocity.x, - rb.velocity.y);
        }
        if (other.gameObject.tag == "Vertical Wall")
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

    }
}
