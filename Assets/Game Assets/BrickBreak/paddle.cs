using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    float hori;
    public float speed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
        speed = speed * ((globalVars.difficulty / 8) + .5f);

    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        pos = tm.position;
        if (!(pos.x + (new Vector2(hori * speed, 0f).normalized.x * .1f) > 2.75) && !(pos.x + (new Vector2(hori * speed, 0f).normalized * .1f).x < -2.75))
        {
            rb.velocity = new Vector2(hori * speed, 0f);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
