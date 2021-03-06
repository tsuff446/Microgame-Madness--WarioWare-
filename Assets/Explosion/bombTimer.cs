﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class bombTimer : MonoBehaviour
{
    public float minTime;
    public static float timeLeft;
    public static bool externEnd = false;
    public static bool exploded = false;
    private GameObject childClock;
    private TextMeshPro countdown;
    private int timeLeftInt;
    private Animator anim;

    void Start()
    {
        Debug.Log("FPS:" + 1 / Time.deltaTime);
        exploded = false;
        externEnd = false;
        timeLeft = minTime + 2 / globalVars.difficulty;
        childClock = this.gameObject.transform.GetChild(0).gameObject;
        countdown = childClock.GetComponent<TextMeshPro>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Default time after loss -> load is 1s
        if (timeLeft < -1f)
        {
            globalVars.songPosition = 0f;
            if (globalVars.gameMode == 0)
                SceneManager.LoadScene(1);
            else if (globalVars.gameMode == 1)
                SceneManager.LoadScene(5);
            else if (globalVars.gameMode == 2)
                SceneManager.LoadScene(6);
            else
                SceneManager.LoadScene(1);
        }

        timeLeftInt = (int)timeLeft;

        //handles explode animation / updating clock
        if (timeLeft <= 0)
        {
            if (!externEnd) {
                countdown.text = "";
                exploded = true;
                anim.SetBool("explode", true);
            }
        }
        else
        {
            countdown.text = timeLeftInt.ToString();
        }

        // if game ends from other source, display nothing
        if (externEnd)
        {
            countdown.text = "";
        }

        timeLeft -= Time.deltaTime;
    }
}
