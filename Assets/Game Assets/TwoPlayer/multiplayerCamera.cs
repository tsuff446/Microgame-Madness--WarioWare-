﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplayerCamera : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        if(globalVars.numPlayers == 2)
        {
            transform.position += new Vector3(0, 2.5f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
