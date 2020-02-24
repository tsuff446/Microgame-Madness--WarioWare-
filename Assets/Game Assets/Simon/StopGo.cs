using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGo : MonoBehaviour
{
    public int idnum;
    float time;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        rend = GetComponent<SpriteRenderer>();
        if (idnum == 2)
        {
            rend.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > Buttons.totaltime)
        {
            if(idnum == 1)
            {
                rend.enabled = false;
            }
            if(idnum == 2)
            {
                rend.enabled = true;
            }
        }
    }
}
