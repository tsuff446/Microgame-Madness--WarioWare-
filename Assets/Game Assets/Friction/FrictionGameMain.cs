using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionGameMain : MonoBehaviour
{
    private GameObject topHand;
    private GameObject bottomHand;
    private Rigidbody2D topBody;
    private Rigidbody2D bottomBody;

    private Vector3 topP = new Vector3(0, 0, 0);
    private Vector3 bottomP = new Vector3(0, 0, 0);
    private float handSpeed = 4f;
    private float maxDist = .35f;
    private Vector3 topV;
    private Vector3 bottomV;

    private float timeElapsed;
    private float spaceCount;
    private GameObject thermoRed;
    private float maxCount;
    private Vector3 thermoP;
    float fillConst = 0f;

    private AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;

    private GameObject flame;

    private GameObject thermometer;
    void Start()
    {
        spaceCount = 0;
        timeElapsed = 0.0f;
        topV = new Vector3(0, handSpeed, 0);
        bottomV = new Vector3(0, -1 * handSpeed, 0);

        topHand = GameObject.Find("topHand").gameObject;
        bottomHand = GameObject.Find("bottomHand").gameObject;
        topBody = topHand.GetComponent<Rigidbody2D>();
        bottomBody = bottomHand.GetComponent<Rigidbody2D>();
        topP = topHand.transform.position;
        bottomP = bottomHand.transform.position;

        thermoRed = GameObject.Find("thermometerRed").gameObject;
        thermoP = thermoRed.transform.position;
        fillConst = 7;
        maxCount = 25 + globalVars.difficulty * 4;

        source = GetComponent<AudioSource>();

        thermometer = GameObject.Find("thermometer").gameObject;

        flame = GameObject.Find("flame");
    }

    void Update()
    {
        //dynamically changing handSpeed based on their rate of button pressing
        timeElapsed += Time.deltaTime;
        if (spaceCount / timeElapsed > handSpeed)
        {
            handSpeed = spaceCount / timeElapsed;
        }else if(spaceCount / timeElapsed < handSpeed && timeElapsed > 1f && spaceCount > 0)
        {
            handSpeed = spaceCount / timeElapsed;
        }

        topV.y = handSpeed * Mathf.Sign(topV.y);
        bottomV.y = handSpeed * Mathf.Sign(bottomV.y);

        //bounding hand poisitions
        if (topHand.transform.position.y - topP.y > maxDist)
        {
            topHand.transform.position = new Vector3(0, maxDist, 0) + topP;
        }else if (topHand.transform.position.y - topP.y < -1*maxDist){
            topHand.transform.position = new Vector3(0, -1*maxDist, 0) + topP;
        }

        if (bottomHand.transform.position.y - bottomP.y > maxDist)
        {
            bottomHand.transform.position = new Vector3(0,maxDist,0) + bottomP;
        }
        else if (bottomHand.transform.position.y - bottomP.y < -1*maxDist)
        {
            bottomHand.transform.position = new Vector3(0,-1*maxDist,0) + bottomP;
        }

        //expanding thermometer and handling wins
        if (spaceCount <= maxCount)
        {
            thermoRed.transform.localScale = new Vector3(.5566f, fillConst * spaceCount / maxCount, 1);
            thermoRed.transform.position = thermoP + new Vector3(0, fillConst * spaceCount / (2 * maxCount), 0);
        }
        else
        {
            if (!bombTimer.exploded && !globalVars.win)
            {
                globalVars.win = true;
                bombTimer.externEnd = true;
                bombTimer.timeLeft = 1f;
                thermometer.GetComponent<AudioSource>().Play(0);
                flame.GetComponent<Animator>().SetBool("win", true);
            }
        }

        // getting input
        if (Input.GetButtonDown("Action"))
        {
            spaceCount++;
            topV = -1 * topV;
            bottomV = -1 * bottomV;
            topBody.velocity = topV;
            bottomBody.velocity = bottomV;
            if(spaceCount % 2 == 1)
            {
                source.Stop();
                source.PlayOneShot(clip1, 1f);
            }
            else
            {
                source.Stop();
                source.PlayOneShot(clip2, 1f);
            }
        }
    }

}
