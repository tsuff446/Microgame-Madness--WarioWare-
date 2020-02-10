﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainScript : MonoBehaviour
{
    private float timer = 0f;
    private AudioSource source;
    private int index;
    private TextMeshPro box;
    public float diffInc;
    private float speedup;
    private float speedUpMult = 4;
    void Start()
    {

        timer = 0f;
        source = GetComponent<AudioSource>();
        box = GetComponent<TextMeshPro>();

        // Handles first text box
        if (globalVars.firstGame)
        {
            box.text = "Good Luck!";
            globalVars.firstGame = false;
            globalVars.win = false;
        }
        else if (globalVars.win)
        {
            box.text = "You Won!";
            globalVars.score++;
            globalVars.difficulty += diffInc;
            globalVars.win = false;
        }
        else
        {
            box.text = "You Lost...";
            globalVars.lives--;
        }
        if (globalVars.lives <= 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            //selects random scene to go to
            index = Random.Range(3, SceneManager.sceneCountInBuildSettings);
            speedup = globalVars.score / speedUpMult + 1f;
            Debug.Log("Speedup:" + speedup.ToString());
            source.pitch = speedup;
            source.Play();
            Debug.Log("Difficulty: " + globalVars.difficulty);
        }
    }

    private void FixedUpdate()
    {
        // times text appearing on screen with the music
        speedup = globalVars.score / speedUpMult + 1f;
        timer += Time.fixedDeltaTime;
        if(timer >= 8.4f / speedup)
        {
            SceneManager.LoadScene(index);
        }
        else if (timer >= 8f / speedup)
        {
            // large cause of errors: when you add a new game make SURE to add a game description string to the array in globalVars
            box.text = globalVars.gameDesc[index];
        }
        else if (timer >= 5.25f / speedup)
        {
            box.text = "Next Game:";
        }
        else if (timer >= 2.43f / speedup)
        {
            box.text = "Score: " + globalVars.score.ToString() + "\nLives: " + globalVars.lives.ToString();
        }

    }
}
