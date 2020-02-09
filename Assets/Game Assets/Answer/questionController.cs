using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class questionController : MonoBehaviour
{

    private TextMeshPro questionBox;
    private bool correct = false;
    private bool played = false;
    private AudioSource source;
    public AudioClip victory;
    public AudioClip wrong;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        DateTime thisDay = DateTime.Today;
        DateTime fakeDate = new DateTime(UnityEngine.Random.Range(1990, 2040), UnityEngine.Random.Range(1, 12), UnityEngine.Random.Range(1, 31));
        int randNum1 = UnityEngine.Random.Range(0, 100);
        int randNum2 = UnityEngine.Random.Range(0, 100);
        //Initializing questions
        string[] questions =
{
            "Today's date is: ",
            randNum1.ToString() + " + " + randNum2.ToString() + " = ",
            (randNum1%10).ToString() + " * " + (randNum2%10).ToString() + " = ",
            "Today is: ",
            "Is this spelled correctly? \n",
            "Is this word spelled backwards? \n"
        };

        questionBox = GetComponent<TextMeshPro>();
        int numQuestions = questions.Length;
        int qIndex = UnityEngine.Random.Range(0, numQuestions);
        string wrongString = "";
        char[] reversed = { };
        //Dictionary of words

        string[] wordDict =
        {
            "elephant",
            "xenon",
            "racecar",
            "helium",
            "array",
            "tweet",
            "selfless",
            "sentences",
            "melon"
        };
        //Setting up misspell
        if(qIndex == 4)
        {
            char[] wrongArray;
            wrongString = wordDict[randNum1 % wordDict.Length];
            wrongArray = wrongString.ToCharArray();
            wrongArray[randNum2 % wrongString.Length] = (char)UnityEngine.Random.Range(97, 122);
            wrongString = new string(wrongArray);
            
        }
        //Setting up reverse
        if(qIndex == 5)
        {
            reversed = wordDict[randNum1 % wordDict.Length].ToCharArray();
            Array.Reverse(reversed);
        }

        string[] correctAnswers = {
            thisDay.ToString("d"),
            (randNum1+randNum2).ToString(),
            ((randNum1%10)*(randNum2%10)).ToString(),
            thisDay.ToString("dddd"),
            wordDict[randNum1%wordDict.Length],
            new string(reversed)

        };

        string[] wrongAnswers =
        {
            fakeDate.ToString("d"),
            ((int)UnityEngine.Random.Range((randNum1+randNum2)*.80f, (randNum1+randNum2)*1.2f)).ToString(),
            ((int)UnityEngine.Random.Range(((randNum1%10)*(randNum2%10))*.80f, ((randNum1%10)*(randNum2%10))*1.2f)).ToString(),
            fakeDate.ToString("dddd"),
            wrongString,
            wordDict[randNum1%wordDict.Length]        
        };

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
                if (!played)
                {
                    source.PlayOneShot(victory, 1f);
                    played = true;
                }
                if (!bombTimer.exploded)
                {
                    globalVars.win = true;
                    bombTimer.externEnd = true;
                    bombTimer.timeLeft = 0f;
                }
            }
            else
            {
                if (!played)
                {
                    source.PlayOneShot(wrong, 1f);
                    played = true;
                }
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
