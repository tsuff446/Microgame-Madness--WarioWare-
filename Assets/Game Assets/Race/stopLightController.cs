using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopLightController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject darkSquare1;
    private GameObject darkSquare2;
    private GameObject darkSquare3;

    private float animTime;
    private float raceStartTime;

    private AudioSource source;
    public AudioClip raceLowSound;
    public AudioClip raceHighSound;

    private float enemyDelay; 
    private GameObject compCar;
    private GameObject playerCar;
    private GameObject finishLine;

    public float carSpeed;

    public AudioClip carVroom;
    public AudioClip crowdBoo;

    private bool gameOver = false;
    private float gameOverTime = 0.0f;
    void Start()
    {
        raceStartTime = 5f - globalVars.difficulty / 25f;
        darkSquare1 = GameObject.Find("darkSquare1");
        darkSquare2 = GameObject.Find("darkSquare2");
        darkSquare3 = GameObject.Find("darkSquare3");
        animTime = 0.0f;

        source = GetComponent<AudioSource>();

        compCar = GameObject.Find("CPUCar");
        playerCar = GameObject.Find("playerCar");
        finishLine = GameObject.Find("finishLine");
        enemyDelay = .36f - (globalVars.difficulty / 250f);
    }

    // Update is called once per frame
    void Update()
    {
        //starts computer car
        if(animTime > enemyDelay + raceStartTime)
        {
            compCar.GetComponent<Rigidbody2D>().velocity = new Vector3(carSpeed, 0, 0);
        }

        //animates stop light
        if (animTime >= raceStartTime && darkSquare3.activeSelf)
        {
            darkSquare3.SetActive(false);
            darkSquare2.SetActive(true);
            darkSquare1.SetActive(true);
            source.PlayOneShot(raceHighSound, 1f);
        }
        else if(animTime > raceStartTime * .666f && darkSquare2.activeSelf && darkSquare3.activeSelf)
        {
            darkSquare2.SetActive(false);
            darkSquare1.SetActive(true);
            source.PlayOneShot(raceLowSound, 1f);
        }
        else if(animTime > raceStartTime * .333f && darkSquare1.activeSelf && darkSquare2.activeSelf && darkSquare3.activeSelf)
        {
            darkSquare1.SetActive(false);
            source.PlayOneShot(raceLowSound, 1f);
        }

        //getting user input from space and arrow keys
        if(Input.GetAxis("Horizontal") > 0 || Input.GetButtonDown("Action") && playerCar.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            if(animTime >= raceStartTime && !gameOver)
            {
                playerCar.GetComponent<Rigidbody2D>().velocity = new Vector3(carSpeed, 0, 0);
                source.PlayOneShot(carVroom, 1f);
            }
            else if(!gameOver)
            {
                playerCar.GetComponent<Rigidbody2D>().velocity = new Vector3(.1f, 0, 0);
                source.PlayOneShot(crowdBoo, 1f);
                globalVars.win = false;
                gameOver = true;
            }
        }

        // checking winner
        if(playerCar.transform.position.x > finishLine.transform.position.x && playerCar.transform.position.x > compCar.transform.position.x && !gameOver)
        {
            globalVars.win = true;
            gameOver = true;
        }
        else if (compCar.transform.position.x > finishLine.transform.position.x && !gameOver)
        {
            globalVars.win = false;
            source.PlayOneShot(crowdBoo, 1f);
            gameOver = true;
        }

        if (gameOver)
        {
            gameOverTime += Time.deltaTime;
            if(gameOverTime > 2.2f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    void FixedUpdate()
    {
        animTime += Time.fixedDeltaTime;
    }
}
