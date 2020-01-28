using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public static bool spiked;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        spiked = false;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((bombTimer.timeLeft < 1f)&&(!(pos.x==Arrow.pos.x)))
        {
            transform.position = new Vector3(pos.x,(float)-3.5,0);
            spiked = true;
        }
    }
}
