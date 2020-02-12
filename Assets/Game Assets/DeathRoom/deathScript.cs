using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class deathScript : MonoBehaviour
{
    private float timeCount = 0f;
    private int playerScore;
    private int changeScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = globalVars.score;


        changeScore = 0;
        if (!PlayerPrefs.HasKey("Score1") || playerScore > PlayerPrefs.GetInt("Score1"))
        {
            changeScore = 1;
        }else if (!PlayerPrefs.HasKey("Score2") || playerScore > PlayerPrefs.GetInt("Score2"))
        {
            changeScore = 2;
        }
        else if (!PlayerPrefs.HasKey("Score3") || playerScore > PlayerPrefs.GetInt("Score3"))
        {
            changeScore = 3;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;
        if (timeCount > 5f)
        {
           if (changeScore == 0)
                SceneManager.LoadScene(4);
           else
                SceneManager.LoadScene(3);
        }
    }
}
