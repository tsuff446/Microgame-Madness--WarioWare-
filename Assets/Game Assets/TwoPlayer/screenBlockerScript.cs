using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenBlockerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNum = 2;
    public Sprite sprite;
    void Start()
    {
        GameObject newSprite = new GameObject("BlockPlayers");
        SpriteRenderer renderer = newSprite.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        if(playerNum == 2)
        {
            newSprite.transform.position = new Vector3(0, -2.5f, 3);
            newSprite.transform.localScale = new Vector2(24f, 5f);
        }
        if(playerNum == 3)
        {
            newSprite.transform.position = new Vector3(6, -2.5f, 3);
            newSprite.transform.localScale = new Vector2(12f, 5f);
        }
    }
}
