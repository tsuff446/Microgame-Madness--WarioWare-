using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songPlay : MonoBehaviour
{
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play(0);
    }

}
