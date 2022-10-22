using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "GameData/Characters", fileName ="Characters List")]
public class CharacterSO : ScriptableObject
{
    public List<Character> characters;
}

[Serializable]
public class Character
{
    public string id;
    public GameObject gamePrefab;
    public GameObject shopPrefab;
    public Sprite shopRender;
    public int price;
}