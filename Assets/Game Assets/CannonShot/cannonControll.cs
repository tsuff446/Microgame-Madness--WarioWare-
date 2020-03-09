using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControll : MonoBehaviour
{
    private Transform tm;
    private float verti = 0f;
    private float turnRate = .25f;
    private float ballVelocity = 15f;
    public GameObject targetObj;
    public GameObject cannonBall;
    private GameObject cracks;
    private AudioSource source;
    public AudioClip clip;
    public AudioClip fire;
    public AudioClip clank;
    int retNum = 50;
    float Vx = 0f;
    float Vy = 0f;
    private GameObject[] reticule = new GameObject[50];
    private float x;
    private float zRad;
    private float y;
    private float  tfin;
    private float t = 0f;
    private float g = 6f;
    private bool fired = false;
    private float lastPlay = -1f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        tm = GetComponent<Transform>();
        cracks = GameObject.Find("cracks");
        tfin = ((2 / g) * ballVelocity * Mathf.Sin(zRad));
        zRad = tm.rotation.eulerAngles.z * (Mathf.PI / 180f);

        for (int i = 0; i < retNum; i++)
        {
            reticule[i] = Instantiate(targetObj);
        }

        t = 0f;

        for (int j = 0; j < retNum; j++)
        {
            t += tfin / retNum;
            x = (tm.position.x + (2 * Mathf.Cos(zRad))) + Mathf.Cos(zRad) * ballVelocity * (t);
            y = -(g/2) * Mathf.Pow(t, 2) + Mathf.Sin(zRad) * ballVelocity * (t) + (tm.position.y + 2 * Mathf.Sin(zRad));
            reticule[j].transform.position = new Vector3(x, y, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        zRad = tm.rotation.eulerAngles.z * (Mathf.PI / 180f);
        tfin = ((2 / g) * ballVelocity * Mathf.Sin(zRad));
        verti = Input.GetAxis("Vertical");

        if(verti > 0 && zRad + turnRate < Mathf.PI/2)
        {
            tm.Rotate(0f, 0f, turnRate, Space.World) ;
        }
        else if (verti < 0 && zRad-turnRate > -.1f)
        {
            tm.Rotate(0f,0f, -1 * turnRate, Space.World);
        }

        if(verti != 0 && Time.time - lastPlay > .9f)
        {
            lastPlay = Time.time;
            source.PlayOneShot(clip,.8f);
        }
        else if(verti == 0 && !fired)
        {
            source.Stop();
            lastPlay = -1f;
        }


        t = 0f;

        for (int j = 0; j < retNum && !fired; j++) { 
            t += tfin / retNum;
            x = (tm.position.x + (2 * Mathf.Cos(zRad))) + Mathf.Cos(zRad) * ballVelocity * (t);
            y = -(g/2) * Mathf.Pow(t, 2) + Mathf.Sin(zRad) * ballVelocity * (t) + (tm.position.y + 2 * Mathf.Sin(zRad));
            reticule[j].transform.position = new Vector3(x, y, 0);
        }



        if (!fired && Input.GetButtonDown("Action"))
        {
            for (int i = 0; i < retNum; i++)
            {
                Destroy(reticule[i]);
            }
            source.PlayOneShot(fire, 1f);
            fired = true;
            cannonBall.transform.position = new Vector3(tm.position.x + (2 * Mathf.Cos(zRad)), tm.position.y + 2 * Mathf.Sin(zRad), 0f);
            Vx = Mathf.Cos(zRad) * ballVelocity;
            Vy = Mathf.Sin(zRad) * ballVelocity;
        }

        if (fired)
        {
            if (cannonBall.transform.position.x > 10.2f && cannonBall.transform.position.x < 11.4f)
            {
                if ((cannonBall.transform.position.y > cracks.transform.position.y + .8f || cannonBall.transform.position.y < cracks.transform.position.y - .8f))
                {
                    Vx = -Vx;
                    source.PlayOneShot(clank, 1f);
                    CannonShotMain.gameLost();
                }
                else
                {
                    CannonShotMain.gameWon();
                }

            }
            cannonBall.transform.position = cannonBall.transform.position + 1.5f*Time.deltaTime * (new Vector3(Vx, Vy, 0));
            Vy -= g * Time.deltaTime*1.5f;
        }
    }
}
