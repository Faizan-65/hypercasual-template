using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<MonoBehaviour>
{
    public PlayerController controller;
    void Start()
    {
        controller.SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
