using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinState : PlayerState
{
    public PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log("Came In Win State");
        controller.swerve.enabled = false;
        controller.playerAnimator.SetTrigger(StringsHolder.winAnim);
        this.controller = controller;
    }

    public override void Exit(PlayerState state)
    {
        controller.swerve.enabled = true;
        controller.SwitchState(state);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
