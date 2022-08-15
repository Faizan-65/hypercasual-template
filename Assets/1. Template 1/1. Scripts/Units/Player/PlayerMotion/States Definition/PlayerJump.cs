using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerMotion
{
    PlayerController controller;
    public override void Enter(PlayerController controller)
    {
        Debug.Log($"JumpState");
        this.controller = controller;
        Jump();
    }
    public override void UpdateState()
    {

    }


    public override void OnCollisionEnter()
    {
        if (controller.collision.gameObject.tag==TagsManager.ground)
        {
            Exit(controller.walkState);
        }
    }

    public override void OnTriggerEnter()
    {

    }

    public override void Exit(PlayerMotion state)
    {
        controller.SwitchState(state);
    }

    private void Jump(float upVelocity = 0, float FWDvel = 0)
    {
        //controller.playerAnimator.SetBool(controller.JUMP, true);
        //controller.rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        //controller.rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        controller.rb.velocity = new Vector3(0f, (controller.jumpVelocityUPWD - upVelocity) * Time.deltaTime,
            (controller.jumpVelocityFWD - FWDvel) * Time.deltaTime);
    }
    public void BetterJump()
    {
        if (controller.rb.velocity.y < 0f)
        {
            controller.rb.velocity += Vector3.up * Physics.gravity.y * (controller.fallMultiplier - 1) * Time.deltaTime;
        }
        //else if (controller.rb.velocity.y > 0f)
        //{
        //    controller.rb.velocity += Vector3.up * Physics.gravity.y * (controller.fallMultiplier - 1) * Time.deltaTime;
        //}
    }
}
