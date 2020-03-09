using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songPlay : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        globalVars.gameMode = 0;
        source = GetComponent<AudioSource>();
        source.time = globalVars.songPosition;
        source.Play(0);
    }
    void Update()
    {
        globalVars.songPosition = source.time;
    }
}
