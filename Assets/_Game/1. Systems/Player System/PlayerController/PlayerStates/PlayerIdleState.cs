using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log("Came In Idle State");
        controller.swerve.enabled = false;
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
