using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinsFormatter
{
    public static string Convert(float coins, string formatting = "#.##")
    {
        if (coins <= 0.001) return "0";
        if (coins < 10000) formatting = "#";
        string postfix = "";
        if (coins > 10000000000)
        {
            postfix = " B";
            coins /= 1000000000;
        }
        if (coins > 10000000)
        {
            postfix = " Kk";
            coins /= 1000000;
        }
        if (coins > 10000)
        {
            postfix = " K";
            coins /= 1000;
        }
        string mainSting = coins.ToString(formatting) + postfix;
        return mainSting;
    }
}
