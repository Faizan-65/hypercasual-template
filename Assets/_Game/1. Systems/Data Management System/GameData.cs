using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int level;
    public int coins;
    public int currentLevelCoins;

    public string characterId;


    public Dictionary<string, bool> purchasedItems;
    public Dictionary<string, bool> unlockedItems;
}
