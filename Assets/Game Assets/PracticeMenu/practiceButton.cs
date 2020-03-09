using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class practiceButton : MonoBehaviour
{
    private Transform tm;
    private SpriteRenderer sp;
    private AudioSource source;
    public AudioClip clip;
    private GameObject transition;
    private bool clicked;
    public GameObject cursor;
    private bool entered;



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
        sp.color = new Color(0, 214, 0);
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
        if (checkCursorCollision() && (Input.GetAxis("Action") > 0 || Input.GetMouseButtonDown(0)) && !clicked )
        {
            source.PlayOneShot(clip, 1f);
            clicked = true;
        }else if (checkCursorCollision() && !clicked && !entered){
            if (!clicked)
            {
                source.PlayOneShot(clip, 1f);
                sp.color = new Color(255, 0, 0);
                tm.localScale = tm.localScale * 1.2f;
                entered = true;
            }
        }
        else if(!checkCursorCollision() && entered)
        {
            if (!clicked)
            {
                sp.color = new Color(0, 214, 0);
                tm.localScale = tm.localScale / 1.2f;
                entered = false;
            }
        }

        if (clicked)
        {
            Debug.Log("Going to Scene " + practice_selection.game_index.ToString() + " with difficulty " + practice_selection.difficulty_index.ToString());
            SceneManager.LoadScene(7 + practice_selection.game_index);
            clicked = !clicked;
        }
        
    }
}
