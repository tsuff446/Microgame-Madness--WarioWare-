using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerController : MonoBehaviour
{
    public int playerNum = 1;
    private Rigidbody2D rb;
    private Transform tm;
    private GameObject player;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>().GetChild(0).gameObject;
        rb = player.GetComponent<Rigidbody2D>();
        tm = player.GetComponent<Transform>();
        if(playerNum > globalVars.numPlayers)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal_Player" + playerNum) != 0)
        {
            rb.velocity += new Vector2(Input.GetAxis("Horizontal_Player" + playerNum), 0);
        }
        if (Input.GetAxis("Vertical_Player" + playerNum) != 0)
        {
            rb.velocity += new Vector2(Input.GetAxis("Vertical_Player" + playerNum), 0);
        }
        if (Input.GetButton("Action"))
        {
            rb.velocity = new Vector2(0, 0);
        }

    }
}
