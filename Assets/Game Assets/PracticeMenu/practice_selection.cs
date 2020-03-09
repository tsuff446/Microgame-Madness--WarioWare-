using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class practice_selection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject game_select;
    private GameObject difficulty_select;
    private GameObject gameText;
    private GameObject diffText;
    public static int game_index;
    public static int difficulty_index;
    private GameObject cursor;
    private AudioSource source;
    public AudioClip clip;

    void Start()
    {
        cursor = GameObject.Find("cursor");
        game_select = transform.GetChild(0).gameObject;
        difficulty_select = transform.GetChild(1).gameObject;
        gameText = transform.GetChild(2).gameObject;
        diffText = transform.GetChild(3).gameObject;
        game_index = 0;
        difficulty_index = 1;

        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (difficulty_index < 1)
            difficulty_index = 10;
        if (game_index < 0)
            game_index = globalVars.gameDesc.Length - 1;

        game_index = game_index % globalVars.gameDesc.Length;
        difficulty_index = (difficulty_index - 1) % 10 + 1;

        gameText.GetComponent<TextMeshPro>().text = globalVars.gameDesc[game_index];
        diffText.GetComponent<TextMeshPro>().text = difficulty_index.ToString();
        globalVars.difficulty = difficulty_index;


        if(Input.GetButtonDown("Action") && cursor.transform.position.x < game_select.transform.position.x + game_select.GetComponent<SpriteRenderer>().bounds.size.x / 2 && cursor.transform.position.x > game_select.transform.position.x - game_select.GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            if (Mathf.Abs(cursor.transform.position.y - game_select.transform.position.y) < game_select.GetComponent<SpriteRenderer>().bounds.size.y / 2)
            {
                if (cursor.transform.position.y > game_select.transform.position.y)
                    game_index++;
                else
                    game_index--;
                source.PlayOneShot(clip);
            }
        }
        if (Input.GetButtonDown("Action") && cursor.transform.position.x < difficulty_select.transform.position.x + difficulty_select.GetComponent<SpriteRenderer>().bounds.size.x / 2 && cursor.transform.position.x > difficulty_select.transform.position.x - difficulty_select.GetComponent<SpriteRenderer>().bounds.size.x / 2)
        {
            if (Mathf.Abs(cursor.transform.position.y - difficulty_select.transform.position.y) < difficulty_select.GetComponent<SpriteRenderer>().bounds.size.y / 2)
            {
                if (cursor.transform.position.y > difficulty_select.transform.position.y && Input.GetButtonDown("Action"))
                    difficulty_index++;
                else
                    difficulty_index--;
                source.PlayOneShot(clip);
            }
            }

    }
}
