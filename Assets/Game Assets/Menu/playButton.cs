using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    private Transform tm;
    private SpriteRenderer sp;
    private AudioSource source;
    public AudioClip clip;
    private float timeElapsed;
    private GameObject transition;
    private bool clicked;
    public GameObject cursor;
    private bool entered;

    private int targetFrameRate = 60;



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

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        clicked = false;
        timeElapsed = 0f;
        tm = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        sp.color = new Color(0, 214, 0);
        transition = GameObject.Find("black");
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
            transition.transform.position = new Vector3(0, 0, 10);
            transition.transform.localScale = new Vector3(30, 30, 1);
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
            timeElapsed += Time.deltaTime;

            if (timeElapsed <4)
            {
                transition.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, timeElapsed/4);
                GameObject.Find("playIntroSong").GetComponent<AudioSource>().volume = 10 - timeElapsed * 2.5f;
            }
            else
            {
                SceneManager.LoadScene(1);
            }

        }
        
    }
}
