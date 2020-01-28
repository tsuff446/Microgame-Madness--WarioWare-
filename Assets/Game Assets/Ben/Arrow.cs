using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public static Vector3 pos;
    public float positionvalue;
    
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
            positionvalue = Random.Range(1, 8);
            pos = new Vector3((float)((2.5 * (double)positionvalue) - 11.25), 3, 0);
            transform.position = pos;
            done = true;
        }
    }
    
}
