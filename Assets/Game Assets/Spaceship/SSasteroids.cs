using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSasteroids : MonoBehaviour
{
    public GameObject g;
    float time;
    float gap;
    public float ymin;
    public float ymax;
    public float xedge;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        gap = .5f / (Mathf.Pow(globalVars.difficulty, .4f));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > gap)
        {
            Instantiate(g, new Vector2(xedge, Random.Range(ymin,ymax)), new Quaternion(0, 0, 0, 0));
            time = 0;
        }
    }
}
