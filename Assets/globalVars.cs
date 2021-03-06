﻿using System.Collections;
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
        "Hit Green!",
        "Hit the Crack!",
        "Heat it up!",
        "Defend!",
        "Wait for Green Light!",
        "Balance!",
        "Pump the Balloon",   
        "Follow the Arrow!",
        "Press if True!",
        "Jump",
        "Hit the Target",
 //       "Copy",
        "Find the Match",
        "Don't Get Hit"
    };
    public static string[] controls =
    {
        "LR",
        "UDA",
        "A",
        "UD",
        "RA",
        "LR",
        "UD",
        "LR",
        "A",
        "LRA",
        "LRUDA",
 //       "LRUD",
        "LRUDA",
        "LRUD"
    };
    //0 is singleplayer, 1 is practice, 2 is multiplayer
    public static int gameMode = 0;

    public static bool[] multWin = { false, false, false, false };
    public static int[] multLives = { 3, 3, 3, 3 };
    public static int numPlayers = 3;

    public static int[] timesPlayed = new int[gameDesc.Length];

    public static float songPosition = 0f;
}
