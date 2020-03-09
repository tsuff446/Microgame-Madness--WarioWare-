using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWin : MonoBehaviour
{
    private bool win;

    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            jump3.Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        JumpMain.gameWon();
        win = true;
    }
}
