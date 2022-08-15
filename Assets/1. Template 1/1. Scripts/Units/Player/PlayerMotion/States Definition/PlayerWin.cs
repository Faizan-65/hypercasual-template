using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : PlayerMotion
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"WinState");
        this.controller = controller;
    }
    public override void UpdateState()
    {

    }


    public override void OnCollisionEnter()
    {

    }

    public override void OnTriggerEnter()
    {

    }

    public override void Exit(PlayerMotion state)
    {
        controller.SwitchState(state);
    }
}
