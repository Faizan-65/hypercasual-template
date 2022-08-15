using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerMotion
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"IdleState");
        this.controller = controller;
        controller.characterController.enabled = false;
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



/*
 
        PlayerMotion
    {
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"IdleState");
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
 
 
 */
