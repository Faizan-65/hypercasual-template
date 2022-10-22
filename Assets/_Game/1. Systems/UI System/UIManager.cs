using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Panels")]
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject winPanel;
    public GameObject loosePanel;
    public GameObject rewardPanel;
    public GameObject settingsPanel;
    public GameObject commonsPanel;

    [Header("Coins")]
    [SerializeField] private Text common_coins;


    [Header("Start Panel")]
    [SerializeField] private Text start_levelNumber;


    [Header("Game Panel")]
    [SerializeField] private Text game_levelNumber;
    [SerializeField] private Image game_levelFill;

    [Header("Win Panel")]
    public Text win_coins;
    public Button win_getButton;
    public Button win_ClaimButton;
    public Text win_claimCoins;
    public Text win_getCoins;
    private void SetUi()
    {
        //common
        common_coins.text = DataManager.gameData.coins.ToString();

        //start panel
        start_levelNumber.text = DataManager.gameData.level.ToString();

        //gamePanel
        game_levelNumber.text = DataManager.gameData.level.ToString();
    }

    private void Update()
    {
        game_levelFill.fillAmount = ReferenceHolder.distancedTraveled / ReferenceHolder.totalDistance;
    }

#region Start Panel Handlers
    public void PlayButtonClickedHandler()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    public void ShopButtonClicked()
    {
        SceneManager.LoadScene("Shop");
    }


    #endregion

    #region Win Panel Handlers

    private bool showRewardPanel=false;
    private bool showKeysPanel=false;
    private IEnumerator OnLevelWin()
    {
        win_coins.text = DataManager.gameData.currentLevelCoins.ToString();
        win_getCoins.text = DataManager.gameData.currentLevelCoins.ToString();
        win_claimCoins.text = DataManager.gameData.currentLevelCoins.ToString();
        gamePanel.SetActive(false);
        yield return new WaitForSeconds(2f);
        winPanel.SetActive(true);
        win_getButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        win_getButton.gameObject.SetActive(true);
    }

    public void WinGetClickedHandler()
    {
        DataManager.gameData.coins += DataManager.gameData.currentLevelCoins;
        win_ClaimButton.interactable=false;
        win_getButton.interactable=false;
        LoadNextLevel();
    }
    public void WinClaimClickedHandler()
    {
        DataManager.gameData.coins += DataManager.gameData.currentLevelCoins;
        win_ClaimButton.interactable = false;
        win_getButton.interactable = false;

        StartCoroutine(CoinsSpreadAnim());
    }
    private void LoadNextLevel()
    {
        DataManager.gameData.level++;
        DataManager.SaveData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator CoinsSpreadAnim()
    {
        yield return new WaitForSeconds(2f);
        LoadNextLevel();
    }
    #endregion

    #region Reward Panel



    #endregion
    public void LevelSpawnedHandler()
    {
        SetUi();
    }

    public void LevelCompletedHandler()
    {
        StartCoroutine(OnLevelWin());
    }
}
