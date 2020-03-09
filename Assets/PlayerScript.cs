using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public static int count=1;
    public static int currCount=0;
    public static int finalCount = 2;
    private AudioSource source;
    public AudioClip noise2;
    int valX;
    int valY;
    // Start is called before the first frame update
    void Start()
    {
        StopAllCoroutines();
        source = GetComponent<AudioSource>();
        currCount = 0;
        count = 1;
        if (globalVars.difficulty > 3)
            finalCount = 2;
        if (globalVars.difficulty > 5)
            finalCount = 3;
        if (globalVars.difficulty > 10)
            finalCount = 4;
        
        
        valX = 1;
        valY = 1;
        rb = GetComponent<Rigidbody>();
        float val = Random.Range(-1f, 1f);
        if (val < -.5)
        {
            valX = -1;
            valY = -1;
        }
        else if (val < 0)
        {
            valX = 1;
            valY = -1;
        }
        else if (val < .5)
        {
            valX = -1;
            valY = 1;
        }
        Debug.Log(currCount);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currCount);
        Debug.Log(finalCount);
        if(currCount==count)
        {
            valX = 1;
            valY = 1;
            rb = GetComponent<Rigidbody>();
            float val = Random.Range(-1f, 1f);
            if (val < -.5)
            {
                valX = -1;
                valY = -1;
            }
            else if (val < 0)
            {
                valX = 1;
                valY = -1;
            }
            else if (val < .5)
            {
                valX = -1;
                valY = 1;
            }
            count += 1;
        }
        rb.velocity = new Vector2(5* valX * Input.GetAxis("Horizontal"), 5 * valY * Input.GetAxis("Vertical"));
        //Debug.Log(currCount);

        if(currCount==finalCount && globalVars.win==false)
        {
            StartCoroutine("end");
            
            
        }
    }
    IEnumerator end ()
    {
        yield return new WaitForSeconds(3f);
        PointsMain.gameWon();
    }
    public void OnCollisionEnter(Collision collision)
    {
        
        source.PlayOneShot(noise2, 1f);
        StartCoroutine("Stop");
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
 
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3.396f);
        rb.constraints = RigidbodyConstraints.None;

    }


}
