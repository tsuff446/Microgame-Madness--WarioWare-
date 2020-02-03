using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class questionController : MonoBehaviour
{

    private TextMeshPro questionBox;
    private bool correct = false;

    // Start is called before the first frame update
    void Start()
    {
        DateTime thisDay = DateTime.Today;
        DateTime fakeDate = new DateTime(UnityEngine.Random.Range(1990, 2040), UnityEngine.Random.Range(1, 12), UnityEngine.Random.Range(1, 31));
        int randNum1 = UnityEngine.Random.Range(0, 100);
        int randNum2 = UnityEngine.Random.Range(0, 100);

        string[] questions =
        {
            "Today's date is: ",
            randNum1.ToString() + " + " + randNum2.ToString() + " = ",
            (randNum1%10).ToString() + " * " + (randNum2%10).ToString() + " = ",
            "Today is: "
        };
        string[] correctAnswers = {
            thisDay.ToString("d"),
            (randNum1+randNum2).ToString(),
            ((randNum1%10)*(randNum2%10)).ToString(),
            thisDay.ToString("dddd")
        };
        string[] wrongAnswers =
        {
            fakeDate.ToString("d"),
            UnityEngine.Random.Range(0, (randNum1+randNum2)).ToString(),
            UnityEngine.Random.Range(0, ((randNum1%10)*(randNum2%10))).ToString(),
            fakeDate.ToString("dddd")
        };
        questionBox = GetComponent<TextMeshPro>();
        int numQuestions = questions.Length;
        int qIndex = UnityEngine.Random.Range(0, numQuestions);
        Debug.Log(numQuestions);
        Debug.Log(qIndex);
        if (UnityEngine.Random.Range(0.0f, 1.0f) > .5f)
        {
            //give correct answer
            correct = true;
            questionBox.text = questions[qIndex] + correctAnswers[qIndex];
            globalVars.win = false;
        }
        else
        {
            //give wrong answer
            correct = false;
            questionBox.text = questions[qIndex] + wrongAnswers[qIndex];
            globalVars.win = true;
        }
        // If the wrong answer happens to equal the right answer change correct to True
        if(correctAnswers[qIndex] == wrongAnswers[qIndex])
        {
            correct = true;
            globalVars.win = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Action"))
        {
            if (correct)
            {
                if (!bombTimer.exploded)
                {
                    globalVars.win = true;
                    bombTimer.externEnd = true;
                    bombTimer.timeLeft = 0f;
                }
            }
            else
            {
                Debug.Log("Loss");
                if (!bombTimer.exploded)
                {
                    globalVars.win = false;
                    bombTimer.externEnd = true;
                    bombTimer.timeLeft = 0f;
                }
            }
        }   
    }
}
