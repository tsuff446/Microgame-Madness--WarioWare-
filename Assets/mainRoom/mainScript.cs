using System.Collections;
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
        }
        //selects random scene to go to
        index = Random.Range(2, SceneManager.sceneCountInBuildSettings);
        source.Play();
        Debug.Log("Difficulty: " + globalVars.difficulty);
    }

    private void FixedUpdate()
    {
        // times text appearing on screen with the music
        timer += Time.fixedDeltaTime;
        if(timer >= 8.4f)
        {
            SceneManager.LoadScene(index);
        }
        else if (timer >= 8f)
        {
            // large cause of errors: when you add a new game make SURE to add a game description string to the array in globalVars
            box.text = globalVars.gameDesc[index];
        }
        else if (timer >= 5.25f)
        {
            box.text = "Next Game:";
        }
        else if (timer >= 2.43f)
        {
            box.text = "Score: " + globalVars.score.ToString();
        }

    }
}
