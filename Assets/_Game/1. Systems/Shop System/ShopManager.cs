using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public CharacterSO charactersSO;
    public GameObject buttonPrefab;
    public Button characterBuyButton;
    public Transform characterButtonsParent;
    public Transform holder3dObject;

    private ItemButton currentButton;
    private ItemButton previousButton;
    private ItemButton globalClicked;
    private ItemButton toBuyButton;
    private void Start()
    {
        DataManager.LoadData();
        SetShop();
    }
    public void SetShop()
    {
        //setcharacterPanel
        foreach (Character character in charactersSO.characters)
        {
            GameObject obj = Instantiate(buttonPrefab, characterButtonsParent);
            obj.GetComponent<Button>().onClick.AddListener(ItemButtonClicked);
            ItemButton script = obj.GetComponent<ItemButton>();
            script.price.text = character.price.ToString();
            script.render.sprite = character.shopRender;
            script.visual3d = character.shopPrefab;
            script.id = character.id;
            DataManager.gameData.purchasedItems.TryGetValue(character.id, out script.purchased);
            DataManager.gameData.unlockedItems.TryGetValue(character.id, out script.unlocked);
            
            if (character.id==DataManager.gameData.characterId)
            {
                currentButton = script;
                characterBuyButton.interactable = false;
                Load3dViewer(currentButton.visual3d);
                script.currentSelected = true;
            }
            script.SetButton();
        }
    }

    public void ItemButtonClicked()
    {
        Debug.Log("Clicked");
        previousButton = currentButton;
        currentButton = EventSystem.current.currentSelectedGameObject.GetComponent<ItemButton>();

        switch (currentButton.state)
        {
            case ButtonState.LOCKED:
                //do nothing
                characterBuyButton.interactable = false;
                break;
            case ButtonState.UNLOCKED:
                Load3dViewer(currentButton.visual3d);
                characterBuyButton.interactable = true;
                toBuyButton = currentButton;
                currentButton = previousButton;
                break;
            case ButtonState.BOUGHT:
                if (previousButton.state == ButtonState.EQUIPED) { previousButton.SetBoughtState(); }
                if (previousButton.state == ButtonState.UNLOCKED) { previousButton.SetUnlockedState(); }
                characterBuyButton.interactable = false;
                currentButton.SetEquipedState();
                Load3dViewer(currentButton.visual3d);
                break;
            case ButtonState.EQUIPED:
                //do nothing
                break;
            default:
                break;
        }
    }
    public void CharacterBuyClicked()
    {
        DataManager.gameData.coins -= Int32.Parse(toBuyButton.price.text);
        DataManager.gameData.purchasedItems[toBuyButton.id] = true;
        DataManager.gameData.characterId = toBuyButton.id;

    }
    
    public void ShopCloseClicked()
    {
        SceneManager.LoadScene("Main");
    }
    public void Load3dViewer(GameObject obj)
    {
        if (true)
        {
            holder3dObject.DestroyChildren();
            Instantiate(obj, holder3dObject);
        }
    }
}
