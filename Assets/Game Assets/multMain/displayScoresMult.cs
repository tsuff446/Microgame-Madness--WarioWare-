using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class displayScoresMult : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNum = 1;
    private TextMeshPro textBox;
    void Start()
    {
        if (playerNum > globalVars.numPlayers)
            this.gameObject.SetActive(false);
        textBox = GetComponent<TextMeshPro>();

        if (!globalVars.firstGame)
        {
            if (globalVars.multWin[playerNum - 1] == false && globalVars.multLives[playerNum - 1] >= 0)
                globalVars.multLives[playerNum - 1]--;
        }
        else
        {
            globalVars.firstGame = false;
        }
        for (int i = 0; i < playerNum; i++)
            globalVars.multWin[i] = false;

        textBox.text = "Lives: " + globalVars.multLives[playerNum-1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Action"))
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }
}
