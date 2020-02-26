﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVars
{
    public static float difficulty = 10f;
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
        "Copy"

    };
    public static int[] timesPlayed = new int[gameDesc.Length];
    public static int numPlayers = 4;
}
