using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balanceMain
{
    public static void gameWon()
    {
        if (!bombTimer.exploded)
        {
            globalVars.win = true;
            bombTimer.externEnd = true;
            bombTimer.timeLeft = 0f;
        }
    }
    public static void gameLost()
    {
        if (!bombTimer.exploded)
        {
            globalVars.win = false;
            bombTimer.externEnd = true;
            bombTimer.timeLeft = 0f;
        }
    }
}
