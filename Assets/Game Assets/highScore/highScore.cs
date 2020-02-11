using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class highScore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] initial = new GameObject[3];
    private char[] letters = new char[3];
    private Transform tm;
    private int selected;
    private bool unPressedX;
    private bool unPressedY;
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    private AudioSource source;
    public AudioClip clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
        unPressedX = true;
        unPressedY = true;
        selected = 0;
        tm = GetComponent<Transform>();
        for(int i = 0; i < 3; i++)
        {
            initial[i] = tm.GetChild(i).gameObject;
            letters[i] = 'a';
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(selected%3 == 2 && Input.GetButtonDown("Action"))
        {
            Debug.Log("Final String: " + letters[0] + letters[1] + letters[2]);
            int playerScore = globalVars.score;
            int changeScore = 0;

            if (!PlayerPrefs.HasKey("Score1") || playerScore > PlayerPrefs.GetInt("Score1"))
            {
                changeScore = 1;
            }
            else if (!PlayerPrefs.HasKey("Score2") || playerScore > PlayerPrefs.GetInt("Score2"))
            {
                changeScore = 2;
            }
            else if (!PlayerPrefs.HasKey("Score3") || playerScore > PlayerPrefs.GetInt("Score3"))
            {
                changeScore = 3;
            }

            PlayerPrefs.SetInt("Score" + changeScore.ToString(), playerScore);
            PlayerPrefs.SetString("Name" + changeScore.ToString(), ""+letters[0] + letters[1] + letters[2]);
            SceneManager.LoadScene(4);
        }
        //Update which box is selected
        if (Input.GetAxis("Horizontal") > 0.5f & unPressedX || (Input.GetButtonDown("Action") && selected != 2))
        {
            unPressedX = false;
            initial[selected].GetComponent<SpriteRenderer>().sprite = unselectedSprite;
            selected = (selected + 1) % 3;
            if (selected < 0)
                selected = 2;
            initial[selected].GetComponent<SpriteRenderer>().sprite = selectedSprite;
            source.PlayOneShot(clip);
        }
        else if (Input.GetAxis("Horizontal") < -0.5f & unPressedX)
        {
            unPressedX = false;
            initial[selected].GetComponent<SpriteRenderer>().sprite = unselectedSprite;
            selected = (selected - 1) % 3;
            if (selected < 0)
                selected = 2;
            initial[selected].GetComponent<SpriteRenderer>().sprite = selectedSprite;
            source.PlayOneShot(clip);
        }
        else if(Input.GetAxis("Horizontal") == 0)
        {
            unPressedX = true;
        }

        //update contents of boxes
        for(int i = 0; i < 3; i++)
        {
            initial[i].transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = letters[i].ToString();
        }
        //update characters for boxes
        if (Input.GetAxis("Vertical") > 0.25f & unPressedY)
        {
            unPressedY = false;
            letters[selected] = (char)((((int)letters[selected] - 97) + 1) % 26 + 97);
            source.PlayOneShot(clip);

        }
        else if (Input.GetAxis("Vertical") < -0.25f & unPressedY)
        {
            unPressedY = false;
            int tempSelected;
            if ((((int)letters[selected] - 97) - 1) < 0)
                tempSelected = 97 + 25;
            else
                tempSelected = ((((int)letters[selected] - 97) - 1) % 26 + 97);

            letters[selected] = (char)tempSelected;
            source.PlayOneShot(clip);

        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            unPressedY = true;
        }

    }
}
