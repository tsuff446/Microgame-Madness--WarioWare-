using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class genButton : MonoBehaviour
{
    private Transform tm;
    private SpriteRenderer sp;
    private AudioSource source;
    public AudioClip clip;
    private GameObject transition;
    private bool clicked;
    public GameObject cursor;
    private bool entered;
    public int R1;
    public int G1;
    public int B1;
    public int R2;
    public int G2;
    public int B2;
    public int destination;



    void Start()
    {
        //was the cursor there last frame
        entered = false;
        Cursor.visible = false;

        globalVars.difficulty = 1f;
        globalVars.win = false;
        globalVars.firstGame = true;
        globalVars.score = 0;
        globalVars.lives = 3;

        clicked = false;
        tm = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

        sp.color = new Color(R1, G1, B1);
        globalVars.gameMode = 1;
    }

    bool checkCursorCollision()
    {
        if (cursor.transform.position.x < this.transform.position.x + sp.bounds.size.x / 2 && cursor.transform.position.x > this.transform.position.x - sp.bounds.size.x / 2)
            if (cursor.transform.position.y < this.transform.position.y + sp.bounds.size.y / 2 && cursor.transform.position.y > this.transform.position.y - sp.bounds.size.y / 2)
                return true;
        return false;
    }
    void Update()
    {
        if (checkCursorCollision() && (Input.GetAxis("Action") > 0 || Input.GetMouseButtonDown(0)) && !clicked)
        {
            source.PlayOneShot(clip, 1f);
            clicked = true;
        }
        else if (checkCursorCollision() && !clicked && !entered)
        {
            if (!clicked)
            {
                source.PlayOneShot(clip, 1f);
                sp.color = new Color(R2, G2, B2);
                tm.localScale = tm.localScale * 1.2f;
                entered = true;
            }
        }
        else if (!checkCursorCollision() && entered)
        {
            if (!clicked)
            {
                sp.color = new Color(R1, G1, B1);
                tm.localScale = tm.localScale / 1.2f;
                entered = false;
            }
        }

        if (clicked)
        {
            SceneManager.LoadScene(destination);
            clicked = !clicked;
        }

    }
}
