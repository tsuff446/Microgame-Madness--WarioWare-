using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerController : MonoBehaviour
{
    public int playerNum = 1;
    private Rigidbody2D rb;
    private Transform tm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tm = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal_Player" + playerNum) != 0)
        {
            rb.AddForce( new Vector2(Input.GetAxis("Horizontal_Player" + playerNum), 0));
        }
        if (Input.GetAxis("Vertical_Player" + playerNum) != 0)
        {
            rb.AddForce(new Vector2(0, Input.GetAxis("Vertical_Player" + playerNum)));
        }
        
    }
}
