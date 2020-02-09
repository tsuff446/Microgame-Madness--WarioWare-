using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVars
{
    public static float difficulty = 1f;
    public static bool win = false;
    public static bool firstGame = true;
    public static int score = 0;
    public static int lives = 3;
    public static string[] gameDesc = {
        "Null",
        "Null",
        "Null",
        "Hit Green!",
        "Break the Wall!",
        "Heat it up!",
        "Defend!",
        "Wait for Green!",
        "Balance!",
        "Pump the Balloon",
        "Watch Out!",
        "Answer!"
    };
    public static int numPlayers = 4;
}
