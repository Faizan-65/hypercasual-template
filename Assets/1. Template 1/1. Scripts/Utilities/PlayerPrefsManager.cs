using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager
{
    static string COINSKEY = "COINS";
    static string SOUNDKEY = "SOUNDS";
    static string LEVELKEY = "LEVEL";

    public static void ClearAllPrefs()
    {

    }

    public static void SetArbitraryPrefs()
    {

    }

    public static void LogAllPrefs()
    {


    }

    public static int GetCoins()
    { return PlayerPrefs.GetInt(COINSKEY); }

    public static void SaveCoins(int coinsAmount)
    { PlayerPrefs.SetInt(COINSKEY, coinsAmount); }

    public static int GetLevel()
    { return PlayerPrefs.GetInt(LEVELKEY); }

    public static void SaveLevel(int level)
    { PlayerPrefs.SetInt(LEVELKEY, level); }


    public static int GetSoundState()
    { return PlayerPrefs.GetInt(SOUNDKEY); }

    public static void SetSoundState(int state)
    { PlayerPrefs.SetInt(SOUNDKEY, state); }

}

