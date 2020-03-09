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
        if (playerNum > globalVars.numPlayers || globalVars.multLives[playerNum-1] <= 0)
        {
            this.gameObject.SetActive(false);
        }
        player = GetComponent<Transform>().GetChild(0).gameObject;
        rb = player.GetComponent<Rigidbody2D>();
        tm = player.GetComponent<Transform>();

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
            rb.velocity += new Vector2(0,Input.GetAxis("Vertical_Player" + playerNum));
        }
        if (Input.GetButton("Action_Player" + playerNum))
        {
            globalVars.multWin[playerNum-1] = true;
            Debug.Log("Player " + playerNum.ToString() + " Wins!");
        }
       
        
    }
}
