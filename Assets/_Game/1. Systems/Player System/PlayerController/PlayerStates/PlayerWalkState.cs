using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    public PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log("Came In Walk State");
        
        this.controller = controller;
        controller.playerAnimator.SetTrigger(StringsHolder.walkAnim);
    }

    public override void Exit(PlayerState state)
    {
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
