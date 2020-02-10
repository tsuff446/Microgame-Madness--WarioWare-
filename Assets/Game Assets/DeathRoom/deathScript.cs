using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class deathScript : MonoBehaviour
{
    public float timeCount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        globalVars.difficulty = 1f;
        globalVars.win = false;
        globalVars.firstGame = true;
        globalVars.score = 0;
        globalVars.lives = 3;
}

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount > 5f)
            SceneManager.LoadScene(0);
    }
}
