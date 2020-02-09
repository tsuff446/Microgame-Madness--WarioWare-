using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightBrick : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] bricks;
    private GameObject selected;
    private Transform tm;
    private int height;
    void Start()
    {
        if(globalVars.difficulty >= 8f)
        {
            height = 4;
        }
        else
        {
            height = (int)Mathf.Ceil(globalVars.difficulty/2f);
        }
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        do
        {
            selected = bricks[Random.Range(1, bricks.Length)];
        } while (selected.transform.position.y / .5 + 1 != height);

        tm = GetComponent<Transform>();
        tm.position = selected.transform.position;
    }
}
