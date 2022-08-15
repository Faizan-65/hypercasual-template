using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRich : PlayerMonetaryBase
{
    PlayerMonetaryController controller;

    public override void Enter(PlayerMonetaryController controller)
    {
        Debug.Log("I'm Rich");
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
    public override void Exit(PlayerMonetaryBase state)
    {
        controller.SwitchState(state);
    }

}
