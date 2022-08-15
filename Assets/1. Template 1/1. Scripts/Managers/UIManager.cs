using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIManager : MonoBehaviour
{


    public GameObject startPanel;
    public GameObject gamePanel;




    #region startPanel Handlers
    public void OnGameStartedBtnHandler()
    {
        OnGameStarted?.Invoke();
        startPanel.SetActive(false);
    }
    #endregion




    #region Events

    public UnityEvent OnGameStarted;

    #endregion

    #region Events Handlers

    #endregion
}
