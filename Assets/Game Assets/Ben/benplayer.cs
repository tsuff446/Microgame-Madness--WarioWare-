using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tm;
    float hori;
    public float speed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        globalVars.win = true;
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        hori = Input.GetAxis("Horizontal");
        pos = tm.position;
        rb.velocity = new Vector2(hori * speed, 0f);
        if (spike.spiked)
        {
            if (((pos.x > (Arrow.pos.x + 1.5)) || (pos.x < (Arrow.pos.x - 1.5)))&&globalVars.win)
            {
                transform.position = new Vector3(100, 100, 100);
                Ben_main.gameLost();
            }
        }
    }
}
