using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static GameData gameData;
    
    public static void LoadData()
    {
        gameData = GameSaver.Load<GameData>("userData") ?? new GameData
        {
            coins = 100,
            level = 1,
            currentLevelCoins = 30,
            characterId = "Character-001",
            unlockedItems = UnlockedListFiller(),
            purchasedItems = PurchasedListFiller()
        };
    }

    private static Dictionary<string, bool> PurchasedListFiller()
    {
        Dictionary<string, bool> collectiveList = new Dictionary<string, bool>();
        foreach (Character item in GameManager.Instance.characterSO.characters)
        {
            collectiveList.Add(item.id, false);
        }
        collectiveList["Character-001"] = true;
        collectiveList["Character-002"] = true;

        return collectiveList;
    }

    private static Dictionary<string, bool> UnlockedListFiller()
    {
        Dictionary<string, bool> collectiveList = new Dictionary<string, bool>();
        foreach (Character item in GameManager.Instance.characterSO.characters)
        {
            collectiveList.Add(item.id, false);
        }
        collectiveList["Character-001"] = true;
        collectiveList["Character-002"] = true;
        collectiveList["Character-003"] = true;
        return collectiveList;
    }
    public static void SaveData()
    {
        GameSaver.Save<GameData>("userData", gameData);
    }
}
