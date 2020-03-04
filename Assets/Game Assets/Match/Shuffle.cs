using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    // Start is called before the first frame update
    static public int[] masterarray;
    static public int length;
    static public int height;
    static public int count;
    int remove;
    static public int dupe;
    static public int dupepos1;
    static public int dupepos2;
    public Sprite[] spritess;
    public Color[] colorss;
    static public float boardwidth;
    static public float boardheight;
    static public float xspacing;
    static public float yspacing;
    int offset;
    static public Vector2 dupeposition1;
    static public Vector2 dupeposition2;
    
    void Start()
    {
        globalVars.win = false;
        boardwidth = 10;
        boardheight = 6;
        dupepos1 = -1;
        length = 0;
        height = 0;
        if(globalVars.difficulty < 2)
        {
            length = 3;
            height = 3;
        }
        if (globalVars.difficulty >= 2 && globalVars.difficulty < 3)
        {
            length = 3;
            height = 3;
        }
        if (globalVars.difficulty >= 3 && globalVars.difficulty < 4)
        {
            length = 4;
            height = 3;
        }
        if (globalVars.difficulty >= 4 && globalVars.difficulty < 6)
        {
            length = 5;
            height = 3;
        }
        if (globalVars.difficulty >= 6 && globalVars.difficulty < 7.5)
        {
            length = 5;
            height = 4;
        }
        if (globalVars.difficulty >= 7.5 && globalVars.difficulty < 9)
        {
            length = 6;
            height = 4;
        }
        if(length == 0)
        {
            length = 6;
            height = 4;
        }
        xspacing = boardwidth / (length-1);
        yspacing = boardheight / (height-1);
        count = length * height;
        remove = Random.Range(0, count);
        dupe = Random.Range(0, count);
        while (dupe == remove)
        {
            dupe = Random.Range(0, count);
        }
        masterarray = new int[count];
        offset = Random.Range(0, 24 - count);
        for (int i = 0; i < count; ++i)
        {
            if(i != remove)
            {
                masterarray[i] = i + offset;
            }
            else
            {
                masterarray[i] = dupe + offset;
            }
        }
        for (int t = 0; t < masterarray.Length; t++)
        {
            int tmp = masterarray[t];
            int r = Random.Range(t, masterarray.Length);
            masterarray[t] = masterarray[r];
            masterarray[r] = tmp;
        }
        for(int i = 0; i < masterarray.Length; ++i)
        {
            if(masterarray[i] - offset == dupe)
            {
                if (dupepos1 == -1)
                {
                    dupepos1 = i;
                }
                else
                {
                    dupepos2 = i;
                }
            }
        }
        GameObject go = new GameObject("New");
        SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
        for (int i = 0; i < length; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                renderer.sprite = spritess[masterarray[height * i + j]];
                if(height * i + j == dupepos1)
                {
                    dupeposition1 = new Vector2(-boardwidth / 2 + xspacing * i, boardheight / 2 - yspacing * j);
                }
                if (height * i + j == dupepos2)
                {
                    dupeposition2 = new Vector2(-boardwidth / 2 + xspacing * i, boardheight / 2 - yspacing * j);
                }
                renderer.color = new Color(colorss[masterarray[height * i + j]].r,colorss[masterarray[height * i + j]].g,colorss[masterarray[height * i + j]].b);
                Instantiate(go, new Vector2(-boardwidth / 2 + xspacing * i, boardheight / 2 - yspacing * j), new Quaternion(0, 0, 0, 0));
            }
        }
        Destroy(go);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
