﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class mainScript : MonoBehaviour
{
    private float timer = 0f;
    private AudioSource source;
    private int index;
    private TextMeshPro box;
    public float diffInc;
    private float speedup;
    private int gameIndex;
    private float speedUpMult = 4;
    private int weightedGameIndex;
    private GameObject dispControls;
    private GameObject directions;
    private GameObject action;
    private bool showControls = false;
    void Start()
    {

        timer = 0f;
        source = GetComponent<AudioSource>();
        box = GetComponent<TextMeshPro>();

        dispControls = this.transform.GetChild(0).gameObject;
        directions = dispControls.transform.GetChild(0).gameObject;
        action = dispControls.transform.GetChild(1).gameObject;
        showControls = false;

        dispControls.SetActive(false);
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
            globalVars.lives--;
            if (globalVars.lives <= 0)
            {
                SceneManager.LoadScene(2);
            }else
            box.text = "You Lost...";
            
        }
        
        //selects random scene to go to
        weightedGameIndex = Random.Range(0, globalVars.timesPlayed.Sum());
        gameIndex = weightToIndex(weightedGameIndex);
        index = gameIndex + 7;
        adjustWeights(gameIndex);
        Debug.Log(globalVars.timesPlayed);
        speedup = globalVars.score / speedUpMult + 1f;
        Debug.Log("Speedup:" + speedup.ToString());
        source.pitch = speedup;
        source.Play();
        Debug.Log("Difficulty: " + globalVars.difficulty);
    }
    private void adjustWeights(int gameIndex)
    {
        for(int i = 0; i < globalVars.timesPlayed.Length; i++)
        {
            if(i != gameIndex)
            {
                globalVars.timesPlayed[i] += 1;
            }
        }
    }

    private int weightToIndex(int weightedGameIndex)
    {
        if(weightedGameIndex == 0)
            return Random.Range(0, globalVars.gameDesc.Length);
        for (int i = 0; i < globalVars.timesPlayed.Length; i++)
        {
            weightedGameIndex -= globalVars.timesPlayed[i];
            if (weightedGameIndex <= 0)
                return i;
        }
        return Random.Range(0, globalVars.gameDesc.Length);
    }
    private void displayControls()
    {
        if (globalVars.controls[gameIndex].Contains("U"))
        {
            directions.transform.GetChild(0).gameObject.SetActive(true);
            showControls = true;
        }
        else
            directions.transform.GetChild(0).gameObject.SetActive(false);

        if (globalVars.controls[gameIndex].Contains("D"))
        {
            directions.transform.GetChild(1).gameObject.SetActive(true);
            showControls = true;
        }
        else
            directions.transform.GetChild(1).gameObject.SetActive(false);

        if (globalVars.controls[gameIndex].Contains("L"))
        {
            directions.transform.GetChild(2).gameObject.SetActive(true);
            showControls = true;
        }
        else
            directions.transform.GetChild(2).gameObject.SetActive(false);

        if (globalVars.controls[gameIndex].Contains("R"))
        {
            directions.transform.GetChild(3).gameObject.SetActive(true);
            showControls = true;
        }
        else
            directions.transform.GetChild(3).gameObject.SetActive(false);

        if (globalVars.controls[gameIndex].Contains("A"))
            action.SetActive(true);
        else
            action.SetActive(false);
        if (showControls)
        {
            directions.SetActive(true);
        }
        else
            directions.SetActive(false);
    }

    private void FixedUpdate()
    {
        // times text appearing on screen with the music
        speedup = globalVars.score / speedUpMult + 1f;
        timer += Time.fixedDeltaTime;
        if(timer >= 8.6f / speedup)
        {
            SceneManager.LoadScene(index);
        }
        else if (timer >= 8f / speedup)
        {
            dispControls.SetActive(true);
            displayControls();
            box.text = globalVars.gameDesc[gameIndex];
            
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
