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

    public int targetFrameRate = 60;



    void Start()
    {
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
    void OnMouseEnter()
    {
        if (!clicked)
        {
            source.PlayOneShot(clip, 1f);
            sp.color = new Color(255, 0, 0);
            tm.localScale = tm.localScale * 1.2f;
        }
    }
    void OnMouseExit()
    {
        if (!clicked)
        {
            sp.color = new Color(0, 214, 0);
            tm.localScale = tm.localScale / 1.2f;
        }
    }
    void OnMouseDown()
    {
        transition.transform.position = new Vector3(0, 0, 10);
        transition.transform.localScale = new Vector3(30, 30, 1);
        clicked = true;
    }
    void Update()
    {
        if (Input.GetButton("Action") && !clicked)
        {
            source.PlayOneShot(clip, 1f);
            transition.transform.position = new Vector3(0, 0, 10);
            transition.transform.localScale = new Vector3(30, 30, 1);
            clicked = true;
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
