using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static Vector3 pos;
    float positionvalue;
    //targetheight is the y value you want the arrow to be at
    public float targetheight;
    //spacing is the distance between the possible positions for the arrow, there is 8 positions evenly divided
    public float spacing;
    //center is the x value of the center of the 8 positions, not an actual position, between positions 4 and 5
    public float center;
    bool done;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        if (globalVars.difficulty > 4)
        {
            time = 2;
        }
        else
        {
            time = 7 - globalVars.difficulty;
        }
        done = false;
        
    }
    private void Update()
    {
        if ((bombTimer.timeLeft < time)&&(!done))
        {
            positionvalue = Random.Range(1, 8) - 4.5f;
            pos = new Vector3((float)((spacing * (double)positionvalue) + center), targetheight, 0);
            transform.position = pos;
            done = true;
        }
    }
    
}
