using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCrack : MonoBehaviour
{
    // Start is called before the first frame update
    private float yPos;
    private AudioSource source;
    bool first = true;
    void Start()
    {
        source = GetComponent<AudioSource>();
        yPos = Random.Range(-4.5f, 2.5f);
        this.transform.position = new Vector3(10.741f, yPos);
        this.transform.GetChild(0).transform.position = new Vector3(10f, yPos);
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update()
    {
        if (globalVars.win && first)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            source.Play(0);
            first = !first;
        }
    }
}
