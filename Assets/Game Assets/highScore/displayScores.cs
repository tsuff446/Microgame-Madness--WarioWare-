using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class displayScores : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshPro textBox;
    void Start()
    {
        textBox = GetComponent<TextMeshPro>();
        textBox.text = "High Scores: \n";
        for(int i = 1; i < 4; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                textBox.text += PlayerPrefs.GetString("Name" + i) + ": " + PlayerPrefs.GetInt("Score" + i).ToString() + "\n";
            }
            else
            {
                textBox.text += "\n";
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Action"))
            SceneManager.LoadScene(0);
    }
}
