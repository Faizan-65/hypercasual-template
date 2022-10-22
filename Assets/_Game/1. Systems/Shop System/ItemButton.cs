using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public ButtonState state;
    public string id;
    public Image lockedIndicator;
    public Image equipedIndicator;
    public Image unlockedIndicator;
    public Image render;
    
    public GameObject priceBar;
    public GameObject visual3d;
    
    
    public Text price;

    [HideInInspector]public bool unlocked=false;
    [HideInInspector]public bool purchased=false;
    [HideInInspector]public bool currentSelected=false;

    

    public void SetButton()
    {
        lockedIndicator.gameObject.SetActive(false);
        equipedIndicator.gameObject.SetActive(false);
        unlockedIndicator.gameObject.SetActive(false);
        if (!unlocked)
        {
            state = ButtonState.LOCKED;
            SetLockedState();
        }
        if (unlocked)
        {
            state = ButtonState.UNLOCKED;
            SetUnlockedState();
        }
        if (purchased && !currentSelected)
        {
            state = ButtonState.UNLOCKED;
            SetBoughtState();
        }
        if (currentSelected)
        {
            Debug.Log($"{009} current selected");
            state = ButtonState.EQUIPED;
            SetEquipedState();
        }
    }
    public void SetLockedState()
    {
        state = ButtonState.LOCKED;
        equipedIndicator.gameObject.SetActive(false);
        unlockedIndicator.gameObject.SetActive(false);
        lockedIndicator.gameObject.SetActive(true);
        render.gameObject.SetActive(false);
        priceBar.SetActive(false);
    }
    public void SetUnlockedState()
    {
        state = ButtonState.UNLOCKED;
        lockedIndicator.gameObject.SetActive(false);
        equipedIndicator.gameObject.SetActive(false);
        unlockedIndicator.gameObject.SetActive(true);
        render.gameObject.SetActive(true);
        priceBar.SetActive(true);
    }
    public void SetBoughtState()
    {
        state = ButtonState.BOUGHT;
        lockedIndicator.gameObject.SetActive(false);
        equipedIndicator.gameObject.SetActive(false);
        unlockedIndicator.gameObject.SetActive(true);
        render.gameObject.SetActive(true);
        priceBar.SetActive(false);
    }
    public void SetEquipedState()
    {
        state = ButtonState.EQUIPED;
        lockedIndicator.gameObject.SetActive(false);
        unlockedIndicator.gameObject.SetActive(false);
        equipedIndicator.gameObject.SetActive(true);
        priceBar.SetActive(false);
        render.gameObject.SetActive(true);
    }
}
