using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStairs : PlayerMotion
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"StairsState");
        this.controller = controller;
        controller.thisCollider.enabled = false;
        controller.rb.isKinematic = true;
        controller.characterController.enabled = true;
    }
    public override void UpdateState()
    {
        controller.characterController.SimpleMove(controller.transform.forward*controller.stairsSpeed*Time.deltaTime);
    }


    public override void OnCollisionEnter()
    {

    }

    public override void OnTriggerEnter()
    {
        if (controller.trigger.tag==TagsManager.ground)
        {
            Exit(controller.walkState);
        }
    }

    public override void Exit(PlayerMotion state)
    {
        controller.thisCollider.enabled = true;
        controller.rb.isKinematic = false;
        controller.characterController.enabled = false;

        controller.SwitchState(state);
    }
}
